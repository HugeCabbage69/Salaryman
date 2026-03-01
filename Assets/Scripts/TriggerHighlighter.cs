using UnityEngine;

public class TriggerHighlighter : MonoBehaviour
{

    public MeshRenderer mesh;
    public bool isIn = false;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mesh.enabled = true;
            isIn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mesh.enabled = false;
            isIn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
