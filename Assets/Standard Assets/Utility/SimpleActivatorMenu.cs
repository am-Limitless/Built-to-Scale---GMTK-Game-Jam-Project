using System;
using UnityEngine;
using UnityEngine.UI;  // Import the UI namespace

namespace UnityStandardAssets.Utility
{
    public class SimpleActivatorMenu : MonoBehaviour
    {
        // A simple menu that switches between game objects
        public Text camSwitchButton;  // Use UI.Text instead of GUIText
        public GameObject[] objects;

        private int m_CurrentActiveObject;

        private void OnEnable()
        {
            // Active object starts from first in the array
            m_CurrentActiveObject = 0;
            camSwitchButton.text = objects[m_CurrentActiveObject].name;
        }

        public void NextCamera()
        {
            int nextactiveobject = m_CurrentActiveObject + 1 >= objects.Length ? 0 : m_CurrentActiveObject + 1;

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(i == nextactiveobject);
            }

            m_CurrentActiveObject = nextactiveobject;
            camSwitchButton.text = objects[m_CurrentActiveObject].name;
        }
    }
}
