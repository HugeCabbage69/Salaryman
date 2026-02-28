using UnityEngine;

public class movement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Camera Reference")]
    [SerializeField] private Transform cameraTransform;

    private float horizontalInput;
    private float verticalInput;

    void Update()
    {
        // Get input (WASD or Arrow keys)
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Get camera forward and right directions
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Remove Y component to keep movement on ground plane
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Calculate movement direction relative to camera
        Vector3 moveDirection = (forward * verticalInput + right * horizontalInput).normalized;

        // Apply movement using Transform
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
