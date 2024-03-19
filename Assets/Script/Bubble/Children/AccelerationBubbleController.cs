using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AccelerationBubbleController : AThinkingBubble
{
    #region Attributs

    [SerializeField] private float _acceleration = 1f; 
    [SerializeField] private float _maxSpeed = 10f;

    private float _startSpeed = 0;

    #endregion ATTRIBUTS

    #region MONO

    void Start()
    {
        GameManager.Instance.OnChangePhase += EscapeDirection;

        _startSpeed = _thinkSpeed;
    }

    void Update()
    {
        UpdatePosition();        
    }
    public void OnDestroy()
    {
        GameManager.Instance.OnChangePhase -= EscapeDirection;
    }
    public void OnApplicationQuit()
    {
        GameManager.Instance.OnChangePhase -= EscapeDirection;
    }

    #endregion MONO

    #region METHODES

    #region ABSTRACTS

    public override void EscapeDirection()
    {
        if (GameManager.Instance.CurrentGamePhase == EGamePhase.REST)
        {
            _thinkSpeed = _startSpeed;
            _escapeDir = Quaternion.Euler(0, 0, Random.Range(0, 360)) * transform.position;
        }        
    }

    public override void Init(Transform target)
    {        
        _focusPosition = target;
    }

    #endregion ABSTRACTS
    public void UpdatePosition()
    {
        switch (GameManager.Instance.CurrentGamePhase)
        {
            case EGamePhase.POMODORO:
                Vector3 dir = (_focusPosition.position - transform.position).normalized;
                _rb.velocity = dir * _thinkSpeed;
                Acceleration();

                break;

            case EGamePhase.REST:
                _rb.velocity = _escapeDir * _thinkSpeed;

                break;

            case EGamePhase.INTERLUDE:
                _rb.velocity = Vector3.zero;

                break;
        }        
    }

    private void Acceleration()
    {
        _acceleration += Time.deltaTime;
        _thinkSpeed = Mathf.Min(_acceleration, _maxSpeed);        
    }

    #endregion Methodes
}
