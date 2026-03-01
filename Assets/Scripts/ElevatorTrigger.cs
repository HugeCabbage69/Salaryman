using UnityEngine;
using TMPro;

public class ElevatorTrigger : MonoBehaviour
{
    public GameObject uiImg;

    public TMP_Text textBlock;   // Drag your TextMeshProUGUI here

    private bool isPlayerInside = false;
    private float cooldown = 0f;

    public bool IsOnCooldown => cooldown > 0f;

    void Update()
    {
        if (cooldown > 0f)
            cooldown -= Time.deltaTime;

        if (isPlayerInside)
            uiImg.SetActive(!IsOnCooldown);

        if (textBlock != null)
            textBlock.text = Mathf.Max(0f, cooldown).ToString("F1") + "s";
    }

    public void StartCooldown(float time)
    {
        cooldown = time;
        uiImg.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerInside = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            uiImg.SetActive(false);
        }
    }
}