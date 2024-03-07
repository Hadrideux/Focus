using System.Collections;
using TMPro;
using UnityEngine;

public class TeleportBubbleController : AThinkingBubble
{
    #region Attributs

    [SerializeField] private float _teleportDelay = 0f;

    [SerializeField] private float _teleportRadius = 1f;

    #endregion Attributs

    #region PROPERTIES
    public float TeleportRadius => _teleportRadius;

    #endregion PROPERTIES

    #region Mono

    void Start()
    {
        StartCoroutine(TeleportRoutine());
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

                break;
        }
    }

    private void TeleportStepwise()
    {
        // D�terminer la direction � appliquer au demi-cercle de t�l�portation        
        Vector3 direction = (FocusPosition.transform.position - transform.position).normalized;

        // Calculer un angle al�atoire dans le demi-cercle de t�l�portation
        float angle = Random.Range(-90, 90); // L'angle est dans la plage de 0 � PI pour un demi-cercle

        direction = (Quaternion.Euler(0, 0, angle) * direction).normalized;

        transform.position += direction * _teleportRadius;
    }
   
    public override void EscapeDirection()
    {
        _escapeDir = Quaternion.Euler(0, 0, Random.Range(0, 360)) * FocusPosition.transform.position;
    }

    #endregion Methodes
}