using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkingBubbleCircleController : AThinkingBubble
{

    #region Attributs

    [Header("Zigzag")]
    [SerializeField] private Vector3 zigzagDirection;
    [SerializeField] private float zigzagTimer;
    [SerializeField] private float zigzagChangeTime = 1.0f; // Temps en secondes avant de changer de direction
    [SerializeField] private float zigzagMagnitude = 1.0f; // Amplitude du zigzag
    [SerializeField] private float ZigZagRadius = 1.0f;

 

    #endregion Attributs

    #region Mono

    void Start()
    {
        StartCoroutine(ZigZagRoutine());
        zigzagTimer = zigzagChangeTime;
        // Initialiser la direction du zigzag vers la droite (ou gauche)
        zigzagDirection = Vector3.right; // ou Vector3.left selon votre préférence
    }

    void Update()
    {
        UpdatePosition();

        zigzagTimer -= Time.deltaTime;

        if (zigzagTimer <= 0)
        {
            // Changer la direction du zigzag
            zigzagDirection = -zigzagDirection;
            zigzagTimer = zigzagChangeTime;
        }

       

    }

    IEnumerator ZigZagRoutine()
    {
        while (Vector3.Distance(transform.position, _focusPosition.transform.position) > ZigZagRadius)
        {
            yield return new WaitForSeconds(zigzagChangeTime);

            Debug.Log("Change");

            // Changer la direction du zigzag
            zigzagDirection = -zigzagDirection;

            ZigZagMovement();
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


    private void ZigZagMovement()
    {
        // Déterminer la direction à appliquer au demi-cercle de zigzag
        Vector3 direction = (FocusPosition.transform.position - transform.position).normalized;

        // Calculer un angle aléatoire dans le demi-cercle de téléportation
        float angle = Random.Range(-90, 90); // L'angle est dans la plage de 0 à PI pour un demi-cercle

        direction = (Quaternion.Euler(0, 0, angle) * direction).normalized;

        //transform.position += direction;
        // Ajouter le mouvement en zigzag à votre logique de déplacement existante
        Vector3 zigzagMove = zigzagDirection * zigzagMagnitude;
        transform.position += zigzagMove * Time.deltaTime;
    }




    #endregion Methodes

}