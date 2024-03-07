using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardTeleportGizmo : MonoBehaviour
{
    [SerializeField] private int _segments = 20;

    [SerializeField] private TeleportBubbleController _controller = null;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = transform.position;

        Vector3 direction = (_controller.FocusPosition.transform.position - center).normalized;

        // Déterminer la rotation à appliquer au demi-cercle
        Quaternion rotation = Quaternion.LookRotation(direction);

        // Calculer le vecteur initial en utilisant la rotation
        Vector3 initialVector = rotation * Vector3.right * _controller.TeleportRadius;
        Vector3 previousPoint = center + initialVector;

        for (int i = 1; i <= _segments; i++)
        {
            float angle = i * Mathf.PI / _segments;
            Vector3 nextPoint = center + rotation * new Vector3(0, Mathf.Cos(angle), Mathf.Sin(angle)) * _controller.TeleportRadius;

            Gizmos.DrawLine(previousPoint, nextPoint);

            previousPoint = nextPoint;
        }
    }
}
