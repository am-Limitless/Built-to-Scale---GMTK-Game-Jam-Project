using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneName; // The name of the next scene to load (e.g., "room2")
    public float delay = 2f; // Delay in seconds before loading the next scene
    public Animator fadeAnimator; // Animator component for fade effect

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player hit the trigger
        {
            StartCoroutine(LoadSceneWithDelay());
        }
    }

    private IEnumerator LoadSceneWithDelay()
    {
        // Start fade out animation
       

        // Wait for the fade-out to complete and add the delay
        yield return new WaitForSeconds(delay);

        // Load the next scene
        SceneManager.LoadScene(sceneName);
    }
}
