using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class TeleportBubbleController : AThinkingBubble
{
    #region ATTRIBUTS

    [Header("Teleport")]
    [SerializeField] private float _teleportDelay = 0f;
    [SerializeField] private float _teleportRadius = 1f;

    private float _startSpeed = 0f;

    private IEnumerator _coroutine = null; 
    
    [SerializeField] Animator _animator = null;
    [SerializeField] private bool _isBlocked = false;

    [SerializeField] private string _animName = null;

    #endregion ATTRIBUTS

    #region PROPERTIES
    public float TeleportRadius => _teleportRadius;

    #endregion PROPERTIES

    #region MONO

    void Start()
    {
        GameManager.Instance.OnChangePhase += EscapeDirection;

        _coroutine = TeleportRoutine();
        StartCoroutine(_coroutine);
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

    IEnumerator TeleportRoutine()
    {
        while (Vector3.Distance(transform.position, _focusPosition.transform.position) > _teleportRadius) 
        {
            yield return new WaitForSeconds(_teleportDelay);
            TeleportStepwise();
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

    #endregion MONO

    #region METHODES

    #region ABSTRACT

    public override void Init(Transform target)
    {
        _focusPosition = target;
    }

    public override void EscapeDirection()
    {
        Debug.Log("Escape Direction");

        if (GameManager.Instance.CurrentGamePhase == EGamePhase.REST)
        {
            _thinkSpeed = _startSpeed;
            _escapeDir = Quaternion.Euler(0, 0, Random.Range(0, 360)) * transform.position;
        }
    }

    #endregion ABSTRACT

    public void UpdatePosition()
    {
        switch (GameManager.Instance.CurrentGamePhase)
        {
            case EGamePhase.POMODORO:
                Vector3 dir = (_focusPosition.position - transform.position).normalized;
                _rb.velocity = dir * _thinkSpeed;

                break;

            case EGamePhase.REST:
                _rb.velocity = _escapeDir * _thinkSpeed;

                break;

            case EGamePhase.INTERLUDE:
                _rb.velocity = Vector3.zero;
                StopCoroutine(_coroutine);

                break;
        }
    }

    private void TeleportStepwise()
    {
        // Déterminer la direction à appliquer au demi-cercle de téléportation        
        Vector3 direction = (FocusPosition.transform.position - transform.position).normalized;

        // Calculer un angle aléatoire dans le demi-cercle de téléportation
        float angle = Random.Range(-90, 90); // L'angle est dans la plage de 0 à PI pour un demi-cercle

        direction = (Quaternion.Euler(0, 0, angle) * direction).normalized;

        transform.position += direction * _teleportRadius;
    }

    private void PlayAnimation()
    {
        _animator.Play(_animName);
    }

    #endregion METHODES
}