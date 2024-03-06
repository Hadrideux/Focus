using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAreaGizmo : MonoBehaviour
{
    [SerializeField] private ThinkSpawner _spawnSpawner = null;

    void OnDrawGizmosSelected()
    {
        //Dessiner des gizmos représentant les zones de spawn
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _spawnSpawner.SpawnDistanceMin);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _spawnSpawner.SpawnDistanceMax);
    }
}
