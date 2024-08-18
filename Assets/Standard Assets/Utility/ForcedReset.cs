using System;
using UnityEngine;
using UnityEngine.SceneManagement; // Updated to use the SceneManager for loading scenes
using UnityEngine.UI; // For working with UI elements like Image
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Image))] // Updated from GUITexture to Image
public class ForcedReset : MonoBehaviour
{
    private void Update()
    {
        // if we have forced a reset ...
        if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
        {
            //... reload the scene using SceneManager
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}
