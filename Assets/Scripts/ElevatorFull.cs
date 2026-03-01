using UnityEngine;
using System.Collections.Generic;

public class ElevatorFull : MonoBehaviour
{
    public ElevatorTrigger elevatorTrigger;

    private Dialogues dialogues;
    private PickupFollower pickupFollower;
    private Deeeds deedsSystem;

    private GameObject spirit;

    public int correctLevel1; // dialogue level
    public int correctLevel2; // bad deed 1
    public int correctLevel3; // bad deed 2
    public int correctLevel4; // bad deed 3

    public Timer time;
    private int alphaCode;

    void Update()
    {

        // --- AUTO FIND REFERENCES IF DESTROYED ---
        if (dialogues == null)
            dialogues = FindObjectOfType<Dialogues>();

        if (pickupFollower == null)
            pickupFollower = FindObjectOfType<PickupFollower>();

        if (deedsSystem == null)
            deedsSystem = FindObjectOfType<Deeeds>();

        if (spirit == null)
            spirit = GameObject.Find("Spirit");


        // --- SAFETY CHECK ---
        if (pickupFollower == null || dialogues == null)
            return;

        if (!pickupFollower.isFollowing)
            return;

        if (elevatorTrigger != null && elevatorTrigger.IsOnCooldown)
            return;

        // --- UPDATE CORRECT LEVELS FROM DEEDS ---
        UpdateCorrectLevels();

        HandleInput();
    }


    void UpdateCorrectLevels()
    {
        correctLevel1 = dialogues.diglvl;

        if (deedsSystem == null)
            return;

        List<BadDeed> bad = deedsSystem.selectedBadDeeds;

        if (bad.Count >= 3)
        {
            correctLevel2 = bad[0].lvl;
            correctLevel3 = bad[1].lvl;
            correctLevel4 = bad[2].lvl;
        }
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
        if (pickupFollower != null)
        {
            Destroy(pickupFollower.gameObject);
            pickupFollower = null; // force re-find next frame
        }

        if (elevatorTrigger != null)
            elevatorTrigger.StartCooldown(alphaCode);

        if (alphaCode == correctLevel1 ||
            alphaCode == correctLevel2 ||
            alphaCode == correctLevel3 ||
            alphaCode == correctLevel4)
        {
            Debug.Log("Correct code entered. Elevator is now full.");
            time.timeLeft = time.timeLeft + 10f;
        }
        else
        {
            Debug.Log("Wrong floor selected.");
            time.timeLeft = time.timeLeft - 20f;
        }

        alphaCode = 0;
    }
}