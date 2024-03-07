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

    private void OnDestroy()
    {
        GameManager.Instance.OnChangePhase -= ChangeBehaviour;
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
        GameManager.Instance.OnChangePhase += ChangeBehaviour;
    }

    private void ChangeBehaviour()
    {

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

    private void TeleportStepwise()
    {
        // Déterminer la direction à appliquer au demi-cercle de téléportation        
        Vector3 direction = (FocusPosition.transform.position - transform.position).normalized;

        // Calculer un angle aléatoire dans le demi-cercle de téléportation
        float angle = Random.Range(-90, 90); // L'angle est dans la plage de 0 à PI pour un demi-cercle

        direction = (Quaternion.Euler(0, 0, angle) * direction).normalized;

        transform.position += direction * _teleportRadius;
    }
   
    #endregion Methodes
}