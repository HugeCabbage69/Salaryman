using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scene Settings")]
    [Tooltip("Name of the gameplay scene to load")]
    public string gameSceneName = "SampleScene";

    /// <summary>
    /// Called when the Play button is clicked.
    /// Loads the main gameplay scene.
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    /// <summary>
    /// Called when the Quit button is clicked.
    /// Exits the application.
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quitting game...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
