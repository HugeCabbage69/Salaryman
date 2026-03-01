using UnityEngine;

public class Bell : MonoBehaviour
{
    [Header("Prefab To Spawn")]
    public GameObject deedPrefab;

    [Header("Spawn Position")]
    public Transform spawnPoint;

    [Header("Key To Ring")]
    public KeyCode ringKey = KeyCode.E;

    private bool isOnCooldown = false;
    public float cooldownTime = 1.5f;
    private float cooldownTimer = 0f;

    void Update()
    {
        // Cooldown timer
        if (isOnCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
                isOnCooldown = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(ringKey))
        {
            TryRingBell();
        }
    }

    void TryRingBell()
    {
        if (isOnCooldown)
            return;

        // Check if any Deeeds object exists
        Deeeds existing = FindObjectOfType<Deeeds>();

        if (existing != null)
        {
            Debug.Log("Cannot ring bell. Deeeds already exists.");
            return;
        }

        SpawnDeedPrefab();
    }

    void SpawnDeedPrefab()
    {
        if (deedPrefab == null)
        {
            Debug.LogWarning("No prefab assigned to Bell.");
            return;
        }

        Vector3 spawnPos = spawnPoint != null ? spawnPoint.position : transform.position;

        Instantiate(deedPrefab, spawnPos, Quaternion.identity);

        isOnCooldown = true;
        cooldownTimer = cooldownTime;

        Debug.Log("Bell rung. Deeeds spawned.");
    }
}