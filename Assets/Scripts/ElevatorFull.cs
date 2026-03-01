using UnityEngine;

public class ElevatorFull : MonoBehaviour
{
    public ElevatorTrigger elevatorTrigger;
    public Dialogues dialogues;
    public PickupFollower pickupFollower;

    public GameObject spirit;

    public int correctLevel1;
    public int correctLevel2;
    public int correctLevel3;
    public int correctLevel4;

    private int alphaCode;

    void Start()
    {
        // Cache references once
        if (dialogues == null)
            dialogues = FindObjectOfType<Dialogues>();

        if (pickupFollower == null)
            pickupFollower = FindObjectOfType<PickupFollower>();

        if (spirit == null)
            spirit = GameObject.Find("Spirit");
    }

    void Update()
    {
        if (!pickupFollower.isFollowing)
            return;

        if (elevatorTrigger.IsOnCooldown)
            return;

        HandleInput();
    }

    void HandleInput()
    {
        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                alphaCode = i;
                ProcessCode();
                break;
            }
        }
    }

    void ProcessCode()
    {
        if (spirit != null)
            Destroy(spirit);

        elevatorTrigger.StartCooldown(alphaCode);

        int dialogueLevel = dialogues.diglvl;
        correctLevel1 = dialogueLevel;

        if (alphaCode == correctLevel1 ||
            alphaCode == correctLevel2 ||
            alphaCode == correctLevel3 ||
            alphaCode == correctLevel4)
        {
            Debug.Log("Correct code entered. Elevator is now full.");
        }
        else
        {
            Debug.Log("Wrong floor selected.");
        }

        alphaCode = 0;
    }
}