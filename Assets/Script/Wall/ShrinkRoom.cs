using UnityEngine;
using System.Collections;

public class ShrinkRoom : MonoBehaviour
{
    public Transform leftWall; // left side wall
    public Transform rightWall; // right side wall
    public float shrinkSpeed = 2f; // speed of wall movement
    public float minDistance = 1f; // min distance of wall
    public float interval = 3f; // interval in seconds between wall movements
    public AudioSource audioSource; // Reference to the AudioSource component

    private bool isShrinking = false; // flag to check if shrinking is happening

    void Start()
    {
        StartCoroutine(ShrinkWallsAtIntervals()); // Start the coroutine
    }

    IEnumerator ShrinkWallsAtIntervals()
    {
        while (true)
        {
            float currentDistance = Vector3.Distance(leftWall.position, rightWall.position);

            if (currentDistance > minDistance)
            {
                // Play the creaking sound if not already playing
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }

                // Smoothly move the walls towards each other over 3 seconds
                float elapsedTime = 0f;
                while (elapsedTime < interval && Vector3.Distance(leftWall.position, rightWall.position) > minDistance)
                {
                    leftWall.position += Vector3.right * shrinkSpeed * Time.deltaTime;
                    rightWall.position += Vector3.left * shrinkSpeed * Time.deltaTime;

                    elapsedTime += Time.deltaTime;
                    yield return null; // Wait for the next frame
                }

                // Stop the sound after the wall movement stops
                audioSource.Stop();
            }
            else
            {
                // Stop the sound if the room can't shrink further
                audioSource.Stop();
            }

            // Wait for 3 seconds before the next movement
            yield return new WaitForSeconds(interval);
        }
    }
}
