using System;
using UnityEngine;
using UnityEngine.UI;  // Add this for UI elements
using UnityStandardAssets.CrossPlatformInput;

public class ForcedReset : MonoBehaviour
{
    private void Update()
    {
        // if we have forced a reset ...
        if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
        {
            //... reload the scene
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
