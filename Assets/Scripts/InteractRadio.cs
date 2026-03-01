using UnityEngine;

public class InteractRadio : MonoBehaviour
{

    public bool isOn = true;
    public AudioSource radioAudio;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isOn = !isOn;
                if (isOn)
                {
                    radioAudio.Play();
                }
                else
                {
                    radioAudio.Stop();
                }
            }
        }
    }
}
