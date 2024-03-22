using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WobbleBubbleController : AThinkingBubble
{
    #region ATTRIBUTS

    private float _startSpeed = 0;

    [SerializeField] private bool _isBlocked = false;
    [SerializeField] Animator _animator = null;
    [SerializeField] private string _animName = null;

    [Header("Rotation Movement")]
    [SerializeField] private float _rotationSpeed = 5.0f;
    [SerializeField] private float _maxRotationRand = 80;
    [SerializeField] private float _distanceThreshold = 2;    

    [Header("Direction Movement")]
    private Vector3 _dir = Vector3.zero;
    private int _dirMult = 1;

    [Header("Timer")]
    [SerializeField] private float _delay = 2f;
    private float _timeStamp = 0;

    #endregion ATTRIBUTS

    #region MONO

    void Start()
    {
        GameManager.Instance.OnChangePhase += EscapeDirection;

        transform.forward = _dir = (_focusPosition.position - transform.position).normalized;
        ChangeDir();

        _startSpeed = _thinkSpeed;
    }
    void Update()
    {
        if (!_isBlocked)
        {
            UpdatePosition();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            _isBlocked = true;
            _rb.velocity = Vector3.zero;

            PlayAnimation();

            if (_animator.GetCurrentAnimatorStateInfo(0).IsName(_animName))
            {
                Destroy(gameObject);
            }
        }
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

    public override void Init(Transform target)
    {
        _focusPosition = target;
    }
    public override void EscapeDirection()
    {
        if (GameManager.Instance.CurrentGamePhase == EGamePhase.REST)
        {
            _thinkSpeed = _startSpeed;
            _escapeDir = Quaternion.Euler(0, 0, Random.Range(0, 360)) * transform.position;
        }
    }

    #endregion ABSTRACTS

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
                    _timeStamp += Time.deltaTime;
                    if (_timeStamp >= _delay)
                    {
                        _timeStamp = 0;
                        _dirMult = -_dirMult;
                        ChangeDir();
                    }

                    transform.forward = Vector3.RotateTowards(transform.forward, _dir, _rotationSpeed * Time.deltaTime, 0.0f);

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
    private void PlayAnimation()
    {
        _animator.Play(_animName);
    }

    #endregion METHODES



}