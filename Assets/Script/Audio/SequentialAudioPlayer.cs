using System.Collections;
using UnityEngine;

public class SequentialAudioPlayer : MonoBehaviour
{
    // Reference to the AudioSource component
    public AudioSource audioSource;

    // Two audio clips to play one after another
    public AudioClip firstClip;
    public AudioClip secondClip;

    void Start()
    {
        // Start playing the audio clips sequentially
        StartCoroutine(PlayAudioSequentially());
    }

    IEnumerator PlayAudioSequentially()
    {
        // Play the first audio clip
        audioSource.clip = firstClip;
        audioSource.Play();

        // Wait for the first clip to finish playing
        yield return new WaitForSeconds(firstClip.length);

        // Play the second audio clip
        audioSource.clip = secondClip;
        audioSource.Play();
    }
}
