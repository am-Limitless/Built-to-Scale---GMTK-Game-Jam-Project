using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Public string variable to be set in the Inspector
    private string sceneName = "Room 1";

    // Method to load the scene
    public void LoadScene()
    {
        // Check if the sceneName is not empty
        if (!string.IsNullOrEmpty(sceneName))
        {
            // Load the scene by name
            SceneManager.LoadScene(sceneName);
            Debug.Log("hI hELLO");
        }
        else
        {
            Debug.LogError("Scene name is empty. Please set a valid scene name in the Inspector.");
        }
    }

    // Method to quit the application
    public void QuitApplication()
    {
        // Quit the application
        Application.Quit();


    }
}
