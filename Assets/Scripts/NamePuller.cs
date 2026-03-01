using UnityEngine;
using UnityEngine.UI;

public class NamePuller : MonoBehaviour
{
    [Header("Legacy UI Text")]
    public Text bookNameText;
    public Text cardNameText;

    private NameGenerator nameGenerator;

    void Update()
    {
        if (nameGenerator == null)
            nameGenerator = FindObjectOfType<NameGenerator>();

        if (nameGenerator == null)
            return;

        bookNameText.text = nameGenerator.bookName;
        cardNameText.text = nameGenerator.cardName;

        if (nameGenerator.areNamesDifferent)
        {
            Debug.Log("WARNING: Book name and Card name are different!");
        }
    }
}