using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkingBubbleCircleController : AThinkingBubble
{

    #region Attributs
    [SerializeField] private float _delay = 2f;
    [SerializeField] private float _rotationSpeed = 5.0f;
    [SerializeField] private float _maxRotationRand = 80;
    [SerializeField] private float _distanceThreshold = 2;

    private int _dirMult = 1;
    private float _timeStamp = 0;
    private Vector3 _dir = Vector3.zero;
    #endregion Attributs

    #region Mono

    void Start()
    {
        transform.forward = _dir = (_focusPosition.position - transform.position).normalized;
        ChangeDir();
    }

    #endregion Mono

    #region Methodes

    void Update()
    {
        UpdatePosition();

        _timeStamp += Time.deltaTime;
        if (_timeStamp >= _delay)
        {
            _timeStamp = 0;
            _dirMult = -_dirMult;
            ChangeDir();
        }

        transform.forward = Vector3.RotateTowards(transform.forward, _dir, _rotationSpeed * Time.deltaTime, 0.0f);
    }

    public override void Init(Transform target)
    {
        _focusPosition = target;
    }

    public void UpdatePosition()
    {
        if (IsInCenter())
        {
            Vector3 dir = (_focusPosition.position - transform.position).normalized;
            _rb.velocity = dir * _thinkSpeed;
        }
        else
        {
            _rb.velocity = transform.forward * _thinkSpeed;
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
    #endregion Methodes

}