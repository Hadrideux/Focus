using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class TeleportBubbleController : AThinkingBubble
{
    #region Attributs

    [Header("Teleport")]
    [SerializeField] private float _teleportDelay = 0f;
    [SerializeField] private float _teleportRadius = 1f;

    private float _startSpeed = 0f;

    private IEnumerator _coroutine = null;

    #endregion Attributs

    #region PROPERTIES
    public float TeleportRadius => _teleportRadius;

    #endregion PROPERTIES

    #region Mono

    void Start()
    {
        _coroutine = TeleportRoutine();
        StartCoroutine(_coroutine);
        _startSpeed = _thinkSpeed;
    }

    void Update()
    {
        UpdatePosition();
    }

    IEnumerator TeleportRoutine()
    {
        while (Vector3.Distance(transform.position, _focusPosition.transform.position) > _teleportRadius) 
        {
            yield return new WaitForSeconds(_teleportDelay);
            TeleportStepwise();
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

    public override void EscapeDirection()
    {
        _thinkSpeed = _startSpeed;
        _escapeDir = Quaternion.Euler(0, 0, Random.Range(0, 360)) * transform.position;
    }

    #endregion Methodes
}