using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThinkingBubbleSquareController : AThinkingBubble
{
    #region Attributs

    [SerializeField] private float _acceleration = 1f; 
    [SerializeField] private float _maxSpeed = 10f; 


    #endregion Attributs

    #region Mono

    void Start()
    {

    }

    void Update()
    {
        UpdatePosition();
        Acceleration();
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

    private void Acceleration()
    {
        _thinkSpeed += _acceleration * Time.deltaTime;
        _thinkSpeed = Mathf.Min(_thinkSpeed, _maxSpeed );
        transform.Translate(_focusPosition.transform.position.normalized * _thinkSpeed * Time.deltaTime);
        
    }

    #endregion Methodes
}
