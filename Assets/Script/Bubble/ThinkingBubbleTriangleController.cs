using System.Collections;
using UnityEngine;

public class ThinkingBubbleTriangleController : AThinkingBubble
{
    #region Attributs

    [SerializeField] private float _teleportDelay = 0f;
    [SerializeField] private float _stepDistance = 1f;

    [SerializeField] private float radius = 1f;

    #endregion Attributs

    
    #region Mono

    void Start()
    {
        StartCoroutine(TeleportRoutine());

        Debug.Log(Vector3.Distance(transform.position, _focusPosition.transform.position));
    }

    void Update()
    {
        UpdatePosition();
    }

    IEnumerator TeleportRoutine()
    {
        while (Vector3.Distance(transform.position, _focusPosition.transform.position) > _stepDistance) 
        {
            yield return new WaitForSeconds(_teleportDelay);
            TeleportStepwise();
        }
    }

    #endregion Mono

    #region Methodes

    public override void Init(GameObject target)
    {
        _focusPosition = target;
    }

    public override void UpdatePosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, _focusPosition.transform.position, _thinkSpeed * Time.deltaTime);        
    }

    private void TeleportStepwise()
    {
        Vector3 currentPosition = transform.position;

        // Calculer un angle aléatoire dans le demi-cercle
        float angle = Random.Range(0f, Mathf.PI); // L'angle est dans la plage de 0 à PI pour un demi-cercle

        // Calculer les coordonnées du point dans le demi-cercle
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        Debug.Log("x : " + x + " et y : " + y);

        Vector3 teleportPoint = new Vector2(x, y);

        transform.position = currentPosition + teleportPoint;
    }
   
    #endregion Methodes
}

/*
   Vector3 direction = (_focusPosition.transform.position - currentPosition).normalized;
   Quaternion rotation = Quaternion.LookRotation(direction);
   Vector3 initialVector = rotation * Vector3.right * radius;
*/