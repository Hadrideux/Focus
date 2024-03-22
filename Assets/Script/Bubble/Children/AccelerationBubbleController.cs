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

    [SerializeField] Animator _animator = null;
    [SerializeField] private bool _isBlocked = false;

    [SerializeField] private string _animName = null;
    #endregion ATTRIBUTS

    #region MONO

    void Start()
    {
        GameManager.Instance.OnChangePhase += EscapeDirection;

        _startSpeed = _thinkSpeed;
    }

    void Update()
    {
        if (!_isBlocked)
        {
            UpdatePosition();
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


    private void PlayAnimation()
    {
        _animator.Play(_animName);
    }

    #endregion Methodes
}
