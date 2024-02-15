using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

public class DragDropUI : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private Vector3 _mouseDragStartPosition;
    [SerializeField] private PointerEventData.InputButton _dragMouseButtonLeft;
    [SerializeField] private RectTransform _rectTransform = null;
    [SerializeField] private int _borderSnapSize = 10;
    [SerializeField] private static HashSet<DragDropUI> allWindows = new HashSet<DragDropUI>();

     
    private void Awake()
    {
        //_selfRect = (RectTransform)transform;
        allWindows.Add(this);
    }

    private void OnDestroy()
    {
        allWindows.Remove(this);
    }

    private void Start()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == _dragMouseButtonLeft)
            _rectTransform.localPosition = Input.mousePosition - _mouseDragStartPosition;
            TrapToScreen();
            SnapEachOther();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == _dragMouseButtonLeft)
        _mouseDragStartPosition = Input.mousePosition - _rectTransform.localPosition;
    }

    //Stay in the camera
    private void TrapToScreen()
    {
        Vector3 diffMin = _rectTransform.position + (Vector3) _rectTransform.rect.position;
        Vector3 diffMax = (Vector3)Camera.main.pixelRect.size - _rectTransform.position + (Vector3)_rectTransform.rect.position;


        if(diffMin.x < _borderSnapSize) _rectTransform.position -= new Vector3(diffMin.x, 0f, 0f);
        if (diffMin.y < _borderSnapSize) _rectTransform.position -= new Vector3(0f, diffMin.y, 0f);
        if (diffMax.x < _borderSnapSize) _rectTransform.position += new Vector3(diffMax.x, 0f, 0f);
        if(diffMax.y < _borderSnapSize) _rectTransform.position += new Vector3(0f, diffMax.y, 0f);
    }

    //Snap on the border to the windows
    private void SnapEachOther()
    {
        foreach(DragDropUI win in allWindows)
        {
            if (win == this)
            {
                continue;
            }

            if (win.gameObject.activeInHierarchy)
            {
                Vector3 DiffMin = win._rectTransform.position - (Vector3) (win._rectTransform.rect.position + _rectTransform.rect.position) - _rectTransform.position;
                Vector3 DiffMax = win._rectTransform.position + (Vector3)(win._rectTransform.rect.position + _rectTransform.rect.position) - _rectTransform.position;

                if (Mathf.Abs(DiffMin.x) < _borderSnapSize) _rectTransform.position += new Vector3(DiffMin.x, 0, 0);
                if (Mathf.Abs(DiffMin.y) < _borderSnapSize) _rectTransform.position += new Vector3(0, DiffMin.y, 0);
                if (Mathf.Abs(DiffMax.x) < _borderSnapSize) _rectTransform.position += new Vector3(DiffMax.x, 0, 0);
                if (Mathf.Abs(DiffMax.y) < _borderSnapSize) _rectTransform.position += new Vector3(0, DiffMax.y, 0);

            }
        }
    }

}
 