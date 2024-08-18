using System;
using UnityEngine;
using UnityEngine.UI; // Added to use UI components

namespace UnityStandardAssets.Utility
{
    public class FPSCounter : MonoBehaviour
    {
        const float fpsMeasurePeriod = 0.5f; // Time interval to measure FPS
        private int m_FpsAccumulator = 0;    // Accumulates frames over the interval
        private float m_FpsNextPeriod = 0;   // Marks the end of the current FPS measurement period
        private int m_CurrentFps;            // Stores the current FPS value
        const string display = "{0} FPS";    // Display format for the FPS text
        private Text m_Text;                 // Reference to the UI Text component for displaying FPS

        private void Start()
        {
            // Set the next measurement period and get the Text component
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
            m_Text = GetComponent<Text>();  // Get the UI Text component
        }

        private void Update()
        {
            // Measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod)
            {
                // Calculate FPS and reset the accumulator for the next period
                m_CurrentFps = (int)(m_FpsAccumulator / fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;

                // Update the UI Text with the current FPS
                if (m_Text != null)
                {
                    m_Text.text = string.Format(display, m_CurrentFps);
                }
            }
        }
    }
}
