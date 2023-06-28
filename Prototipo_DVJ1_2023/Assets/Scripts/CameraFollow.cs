using System.Collections;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float minDistance = 4f;  // Distancia mmin. entre los jugadores
    public float maxDistance = 8f;  // Distancia máx. entre los jugadores
    public float smoothTime = 0.3f;  // Suavidad del movimiento de la cam.
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    private IEnumerator Start()
    {
        while (true)
        {
            float distance = Vector3.Distance(player1.position, player2.position);
            if (distance > 15 && distance < 16)
            {
                maxDistance = 9;
                smoothTime = 0.5f;
            }
            else if (distance > 16)
            {
                maxDistance = 16;
                smoothTime = 0.6f;
            }
            float targetDistance = Mathf.Clamp(distance, minDistance, maxDistance);
            Vector3 targetPosition = (player1.position + player2.position) / 2f + offset * targetDistance;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            yield return null;
        }
    }
}