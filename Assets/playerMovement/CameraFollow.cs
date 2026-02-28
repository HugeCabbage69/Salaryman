using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Follow Settings")]
    [SerializeField] public float smoothSpeed = 5f;
    [SerializeField] public Vector3 offset = new Vector3(0f, 0f, -10f);

    void LateUpdate()
    {
        if (target == null)
            return;

        // Calculate desired position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate to desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Apply position
        transform.position = smoothedPosition;

        // Rotate to face the player
        transform.LookAt(target);
    }
}