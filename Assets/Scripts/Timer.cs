using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float timeLeft = 60f;

    [Header("UI")]
    public Text timerText;

    [Header("Player Tracking")]
    public float totalTimeAlive = 0f;
    public bool isPlayerAlive = true;

    void Update()
    {
        if (!isPlayerAlive)
            return;

        totalTimeAlive += Time.deltaTime;
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            GameOver();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time Left: " + Mathf.Ceil(timeLeft).ToString();
        }
    }

    private void GameOver()
    {
        isPlayerAlive = false;

        Debug.Log("Time's up! The player died.");
        Debug.Log("Total Time Alive: " + Mathf.Round(totalTimeAlive) + " seconds.");

        SceneManager.LoadScene("mainMenu");
    }
}