using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    private float horizontalInput;
    private float verticalInput;

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        transform.position += moveDirection * moveSpeed * Time.fixedDeltaTime;
    }
}
