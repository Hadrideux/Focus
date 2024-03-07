using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AccelerationBubbleController : AThinkingBubble
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

    public override void Init(Transform target)
    {
        _focusPosition = target;
    }

    public void UpdatePosition()
    {
        Vector3 dir = (_focusPosition.position - transform.position).normalized;

        if (GameManager.Instance.CurrentGamePhase == EGamePhase.POMODORO)
        {            
            _rb.velocity = dir * _thinkSpeed;
        }
        else if (GameManager.Instance.CurrentGamePhase == EGamePhase.REPOS)
        {
            _rb.velocity -= dir * _thinkSpeed;
        }
        
    }

    private void Acceleration()
    {
        _thinkSpeed += _acceleration * Time.deltaTime;
        _thinkSpeed = Mathf.Min(_thinkSpeed, _maxSpeed);        
    }

    #endregion Methodes
}
