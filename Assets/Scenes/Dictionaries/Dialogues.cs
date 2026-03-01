using System.Collections.Generic;
using UnityEngine;

public class Dialogues : MonoBehaviour
{
    private List<(string dialogue, float weight, int level)> dialogues = new List<(string, float, int)>();
    public string digStr;
    public int diglvl;

    void Start()
    {
        dialogues.Add(("God is a lie.", 0.5f, 6));
        dialogues.Add(("It was just sex.", 0.5f, 2));
        dialogues.Add(("He trusted me. That's why I won.", 0.5f, 9));
        dialogues.Add(("I only told them where he was hiding.", 0.5f, 9));
        dialogues.Add(("War needs sacrifices.", 0.5f, 7));
        dialogues.Add(("I ate because I could.", 0.5f, 3));
        dialogues.Add(("They signed the contract.", 0.5f, 0));
        dialogues.Add(("It's not fraud. It's smart accounting.", 0.5f, 9));
        dialogues.Add(("Everyone cheats.", 0.5f, 0));
        dialogues.Add(("I didn't push him. I just didn't pull him up.", 0.5f, 0));
        dialogues.Add(("Faith is for fools.", 0.5f, 6));
        dialogues.Add(("Love is love. All of it.", 0.5f, 2));
        dialogues.Add(("I deserved more.", 0.5f, 0));
        dialogues.Add(("I kept the donations. They would've wasted them.", 0.5f, 8));
        dialogues.Add(("He was my brother. But I chose myself.", 0.5f, 9));
        dialogues.Add(("I burned it for the insurance.", 0.5f, 8));
        dialogues.Add(("They were animals anyway.", 0.5f, 7));
        dialogues.Add(("I only hurt myself.", 0.5f, 7));
        dialogues.Add(("I made them believe I was chosen.", 0.5f, 8));
        dialogues.Add(("It’s not greed if you win.", 0.5f, 0));
        dialogues.Add(("I just watched.", 0.5f, 0));
        dialogues.Add(("They followed me willingly.", 0.5f, 0));
        dialogues.Add(("I didn’t mean for it to go that far.", 0.5f, 0));
        dialogues.Add(("He forgave me. That should count.", 0.5f, 0));
        dialogues.Add(("I never believed in souls.", 0.5f, 6));
        dialogues.Add(("I sold secrets.", 0.5f, 9));
        dialogues.Add(("I loved money more.", 0.5f, 4));
        dialogues.Add(("Truth is whatever works.", 0.5f, 8));
        dialogues.Add(("He begged. I laughed.", 0.5f, 7));
    }

    
    public (string dialogue, float weight, int level) GetDialogue()
    {
        
        if (dialogues.Count == 0)
        {
            return ("No dialogue available.", 0f, 0);
        }

        float totalWeight = 0f;

        foreach (var entry in dialogues)
        {
            totalWeight += entry.weight;
        }

        float randomWeight = Random.Range(0f, totalWeight);
        float cumulativeWeight = 0f;

        foreach (var entry in dialogues)
        {
            cumulativeWeight += entry.weight;
            if (randomWeight < cumulativeWeight)
            {
                return entry;
            }
        }

       
        return dialogues[dialogues.Count - 1];
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            var dig = GetDialogue();

            
            digStr = dig.dialogue;
            diglvl = dig.level;

            
            Debug.Log($"Level {diglvl}: {digStr}");
        }
    }
}