using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the same game object
        audioSource = GetComponent<AudioSource>();

        // Start playing the music
        audioSource.Play();
    }

    void Update()
    {
        // You can add additional logic here to control the music, such as pausing, stopping, or changing tracks.
    }
}
