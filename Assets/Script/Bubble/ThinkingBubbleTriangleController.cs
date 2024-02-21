using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkingBubbleTriangleController : AThinkingBubble
{
    #region Attributs

    [SerializeField] private float _teleportDelay = 0f;
    [SerializeField] private float _stepDistance = 1f;

    #endregion Attributs

    #region Mono

    void Start()
    {
        StartCoroutine(TeleportRoutine());
    }

    void Update()
    {
        UpdatePosition();
    }

    #endregion Mono

    #region Methodes

    public override void Init(GameObject target)
    {
        _focusPosition = target;
    }

    public override void UpdatePosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, _focusPosition.transform.position, _thinkSpeed * Time.deltaTime);
    }

    IEnumerator TeleportRoutine()
    {
        while (Vector3.Distance(transform.position, _focusPosition.transform.position) > _stepDistance) 
        {
            yield return new WaitForSeconds(_teleportDelay);
        }

        TeleportStepwise();
    }

    private void TeleportStepwise()
    {
        if(_focusPosition != null)
        {
            Vector3 direction = (_focusPosition.transform.position - transform.position).normalized;
            Vector3 nextStepPostion = transform.position + direction * _stepDistance;

            float distanceToFocusPosition = Vector3.Distance(transform.position, _focusPosition.transform.position);
            if(distanceToFocusPosition < _stepDistance) 
            {
                nextStepPostion = _focusPosition.transform.position - direction * distanceToFocusPosition;
            }

            transform.position = nextStepPostion;
        }
    }
    
    #endregion Methodes


}
