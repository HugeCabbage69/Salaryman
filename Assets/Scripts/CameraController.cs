using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    [Header("Offset Settings")]
    public float offsetX = 0f;
    public float offsetY = 10f;
    public float offsetZ = -10f;

    [Header("Smooth Settings")]
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + new Vector3(offsetX, offsetY, offsetZ);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Always look at player
        transform.LookAt(target);
    }
}