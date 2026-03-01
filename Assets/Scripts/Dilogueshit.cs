using UnityEngine;
using UnityEngine.UI;

public class Dilogueshit : MonoBehaviour
{
    private Dialogues dialogues;

    [Header("Legacy UI Text")]
    public Text dialogueText;

    void Update()
    {
        // Auto-find if prefab respawns
        if (dialogues == null)
            dialogues = FindObjectOfType<Dialogues>();

        if (dialogues == null || dialogueText == null)
            return;

        // Update UI text
        dialogueText.text = dialogues.digStr;
    }
}