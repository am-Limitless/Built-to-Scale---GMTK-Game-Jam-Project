using System;
using UnityEngine;
using UnityEngine.UI; // Make sure this is added to use the new UI system.

namespace UnityStandardAssets.Utility
{
    public class SimpleActivatorMenu : MonoBehaviour
    {
        // A simple menu that switches between referenced gameobjects in the scene
        public Text camSwitchButton; // Changed GUIText to Text
        public GameObject[] objects;

        private int m_CurrentActiveObject;

        private void OnEnable()
        {
            // Active object starts from the first in the array
            m_CurrentActiveObject = 0;
            camSwitchButton.text = objects[m_CurrentActiveObject].name;
        }

        public void NextCamera()
        {
            // Cycle through objects and activate the next one
            int nextactiveobject = m_CurrentActiveObject + 1 >= objects.Length ? 0 : m_CurrentActiveObject + 1;

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(i == nextactiveobject);
            }

            // Update the active object and button text
            m_CurrentActiveObject = nextactiveobject;
            camSwitchButton.text = objects[m_CurrentActiveObject].name;
        }
    }
}
