using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TopDownPlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float rotationSpeed = 12f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Transform cam;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(horizontal, 0f, vertical).normalized;

        if (input.magnitude > 0.1f)
        {
            // Flatten camera direction completely
            Vector3 camForward = cam.forward;
            Vector3 camRight = cam.right;

            camForward.y = 0f;
            camRight.y = 0f;

            camForward.Normalize();
            camRight.Normalize();

            // Movement relative to camera (on XZ only)
            Vector3 moveDir = camForward * vertical + camRight * horizontal;

            // Move on ground only
            controller.Move(moveDir * moveSpeed * Time.deltaTime);

            // Rotate toward movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -0.2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}