using UnityEngine;
using System.Collections;

public class ShrinkRoom1 : MonoBehaviour
{
    public Transform leftWall; // left side wall
    public Transform rightWall; // right side wall (stationary)
    public float shrinkSpeed = 2f; // speed of wall movement
    public float minDistance = 1f; // min distance between walls
    public float interval = 3f; // interval in seconds between wall movements
    public AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        StartCoroutine(ShrinkWallAtIntervals()); // Start the coroutine
    }

    IEnumerator ShrinkWallAtIntervals()
    {
        while (true)
        {
            float currentDistance = Vector3.Distance(leftWall.position, rightWall.position);

            if (currentDistance > minDistance)
            {
                // Play the creaking sound if it's not already playing
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }

                // Smoothly move only the left wall towards the right wall
                float elapsedTime = 0f;
                while (elapsedTime < interval && Vector3.Distance(leftWall.position, rightWall.position) > minDistance)
                {
                    leftWall.position += Vector3.left * shrinkSpeed * Time.deltaTime; // Move the leftWall towards rightWall

                    elapsedTime += Time.deltaTime;
                    yield return null; // Wait for the next frame
                }

                // Stop the sound after the wall movement stops
                audioSource.Stop();
            }
            else
            {
                // Stop the sound if the wall can't shrink further
                audioSource.Stop();
            }

            // Wait for 3 seconds before the next movement
            yield return new WaitForSeconds(interval);
        }
    }
}
