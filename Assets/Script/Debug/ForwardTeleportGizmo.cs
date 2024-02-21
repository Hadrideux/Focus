using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardTeleportGizmo : MonoBehaviour
{

    [SerializeField] private float radius = 1f;
    [SerializeField] private int segments = 20;

    [SerializeField] private AThinkingBubble _tinkingBubble = null;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = transform.position;

        Vector3 _direction = (_tinkingBubble.FocusPosition.transform.position - center).normalized;

        // Déterminer la rotation à appliquer au demi-cercle
        Quaternion rotation = Quaternion.LookRotation(_direction);

        // Calculer le vecteur initial en utilisant la rotation
        Vector3 initialVector = rotation * Vector3.right * radius;
        Vector3 previousPoint = center + initialVector;

        for (int i = 1; i <= segments; i++)
        {
            float angle = i * Mathf.PI / segments;
            Vector3 nextPoint = center + rotation * new Vector3(0, Mathf.Cos(angle), Mathf.Sin(angle)) * radius;

            Gizmos.DrawLine(previousPoint, nextPoint);

            previousPoint = nextPoint;
        }
    }
}
