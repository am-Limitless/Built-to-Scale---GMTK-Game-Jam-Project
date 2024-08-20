using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Public string variable to be set in the Inspector
    public string sceneName;

    // Method to load the scene
    public void LoadScene()
    {
        // Check if the sceneName is not empty
        if (!string.IsNullOrEmpty(sceneName))
        {
            // Load the scene by name
            SceneManager.LoadScene(sceneName);
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
