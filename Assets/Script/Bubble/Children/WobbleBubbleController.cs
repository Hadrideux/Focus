using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WobbleBubbleController : AThinkingBubble
{

    #region Attributs
    [SerializeField] private float _delay = 2f;
    [SerializeField] private float _rotationSpeed = 5.0f;
    [SerializeField] private float _maxRotationRand = 80;
    [SerializeField] private float _distanceThreshold = 2;

    private int _dirMult = 1;
    private float _timeStamp = 0;
    private Vector3 _dir = Vector3.zero;

    private float _startSpeed = 0;

    #endregion Attributs

    #region Mono

    void Start()
    {
        transform.forward = _dir = (_focusPosition.position - transform.position).normalized;
        ChangeDir();

        _startSpeed = _thinkSpeed;
    }
    void Update()
    {
        UpdatePosition();

        if(GameManager.Instance.CurrentGamePhase == EGamePhase.POMODORO)
        {
            _timeStamp += Time.deltaTime;
            if (_timeStamp >= _delay)
            {
                _timeStamp = 0;
                _dirMult = -_dirMult;
                ChangeDir();
            }

            transform.forward = Vector3.RotateTowards(transform.forward, _dir, _rotationSpeed * Time.deltaTime, 0.0f);
        }
    }

    #endregion Mono

    #region Methodes

    public override void Init(Transform target)
    {
        _focusPosition = target;
    }

    public void UpdatePosition()
    {
        switch (GameManager.Instance.CurrentGamePhase)
        {
            case EGamePhase.POMODORO:
                if (IsInCenter())
                {
                    Vector3 dir = (_focusPosition.position - transform.position).normalized;
                    _rb.velocity = dir * _thinkSpeed;
                }
                else
                {
                    _rb.velocity = transform.forward * _thinkSpeed;
                }

                break;

            case EGamePhase.REST:
                _rb.velocity = _escapeDir * _thinkSpeed;

                break;

            case EGamePhase.INTERLUDE:
                _rb.velocity = Vector3.zero;

                break;
        }        
    }

    private void ChangeDir()
    {
        _dir = (_focusPosition.position - transform.position).normalized;
        _dir = Quaternion.Euler(0,0, _maxRotationRand * _dirMult) * _dir;
    }

    private bool IsInCenter()
    {
        return Vector3.Distance(transform.position, _focusPosition.position) <= _distanceThreshold;
    }

    public override void EscapeDirection()
    {
        _thinkSpeed = _startSpeed;
        _escapeDir = Quaternion.Euler(0, 0, Random.Range(0, 360)) * transform.position;
    }

    #endregion Methodes

}