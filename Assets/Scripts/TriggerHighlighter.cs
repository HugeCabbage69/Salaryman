using UnityEngine;

public class TriggerHighlighter : MonoBehaviour
{

    public MeshRenderer mesh;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mesh.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mesh.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
