using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAreaGizmo : MonoBehaviour
{
    [Header("Spawn Location")]
    [SerializeField] private float _minSpawnDistance = 0;
    [SerializeField] private float _maxSpawnDistance = 0;

    void OnDrawGizmosSelected()
    {
        //Dessiner des gizmos représentant les zones de spawn
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _minSpawnDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _maxSpawnDistance);
    }
}
