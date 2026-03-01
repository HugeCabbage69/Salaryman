using System.Collections.Generic;
using UnityEngine;

public class NameGenerator : MonoBehaviour
{
    [Header("Generated Results")]
    public string bookName;
    public string cardName;

    [Tooltip("This checkbox automatically updates based on whether the names match.")]
    public bool areNamesDifferent;

    private string[] boyNames = new string[]
    {
        "Liam", "Noah", "Oliver", "Elijah", "James", "William", "Benjamin", "Lucas", "Henry", "Theodore",
        "Jack", "Levi", "Alexander", "Jackson", "Mateo", "Daniel", "Michael", "Mason", "Sebastian", "Ethan",
        "Logan", "Owen", "Samuel", "Jacob", "Asher", "Aiden", "John", "Joseph", "Wyatt", "David",
        "Leo", "Luke", "Julian", "Hudson", "Grayson", "Matthew", "Ezra", "Gabriel", "Carter", "Isaac",
        "Jayden", "Luca", "Lincoln", "Anthony", "Dylan", "Thomas", "Charles", "Christopher", "Jaxon", "Maverick"
    };

    private string[] girlNames = new string[]
    {
        "Olivia", "Emma", "Charlotte", "Amelia", "Ava", "Sophia", "Isabella", "Mia", "Evelyn", "Harper",
        "Luna", "Camila", "Gianna", "Elizabeth", "Eleanor", "Ella", "Abigail", "Sofia", "Avery", "Scarlett",
        "Emily", "Aria", "Penelope", "Chloe", "Layla", "Mila", "Nora", "Hazel", "Madison", "Ellie",
        "Lily", "Nova", "Isla", "Grace", "Violet", "Aurora", "Riley", "Zoey", "Willow", "Emilia",
        "Stella", "Zoe", "Victoria", "Hannah", "Addison", "Lucy", "Eliana", "Ivy", "Everly", "Josephine"
    };

    private List<string> allNames = new List<string>();

    private void Awake()
    {
        allNames.AddRange(boyNames);
        allNames.AddRange(girlNames);
    }

    private void Start()
    {
        GenerateNames();
    }

    [ContextMenu("Generate Names")]
    public void GenerateNames()
    {
        if (allNames.Count == 0)
        {
            allNames.AddRange(boyNames);
            allNames.AddRange(girlNames);
        }

        float randomChance = Random.Range(0f, 1f);

        if (randomChance <= 0.05f)
        {
            bookName = GetRandomName();
            cardName = GetRandomName();

            while (bookName == cardName)
            {
                cardName = GetRandomName();
            }

            areNamesDifferent = true; 
        }
        else 
        {
            string sharedName = GetRandomName();
            bookName = sharedName;
            cardName = sharedName;

            areNamesDifferent = false; 
        }
    }

    private string GetRandomName()
    {
        int randomIndex = Random.Range(0, allNames.Count);
        return allNames[randomIndex];
    }
}