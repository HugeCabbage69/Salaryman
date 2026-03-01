using System.Reflection;
using UnityEngine;

public class BookTrigger : MonoBehaviour
{

    public GameObject UiImg; 
    public bool isIn = false;

    public float Cooldown = 0f;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Cooldown <= 0f)
        {
            UiImg.SetActive(true);
            isIn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UiImg.SetActive(false);
            isIn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
