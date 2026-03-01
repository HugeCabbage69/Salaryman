using UnityEngine;

public class PickupFollower : MonoBehaviour
{
    [Header("Follow Settings")]
    public float followSpeed = 5f;

    [Header("Snap Settings")]
    public Transform snapPoint;
    public float snapDistance = 0.5f;

    private Transform player;
    private bool canInteract = false;
    public bool isFollowing = false;

    private Vector3 followOffset; // locked offset

    void Update()
    {
        if (canInteract && !isFollowing && Input.GetKeyDown(KeyCode.F))
        {
            StartFollowing();
        }

        if (isFollowing && player != null)
        {
            FollowPlayer();

            if (snapPoint != null &&
                Vector3.Distance(transform.position, snapPoint.position) <= snapDistance)
            {
                SnapToPoint();
            }
        }
    }

    public void SetPlayer(Transform p)
    {
        player = p;
        canInteract = true;
    }

    void StartFollowing()
    {
        isFollowing = true;

        // Lock current relative offset
        followOffset = transform.position - player.position;
    }

    void FollowPlayer()
    {
        Vector3 targetPos = player.position + followOffset;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            followSpeed * Time.deltaTime
        );
    }

    void SnapToPoint()
    {
        transform.position = snapPoint.position;
        transform.rotation = snapPoint.rotation;
        isFollowing = false;
        enabled = false;
    }
}