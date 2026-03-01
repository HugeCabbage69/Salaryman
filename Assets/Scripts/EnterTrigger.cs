using UnityEngine;

public class EnterTrigger : MonoBehaviour
{
    public PickupFollower parentObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parentObject.SetPlayer(other.transform);
        }
    }
}