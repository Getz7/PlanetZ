using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonidos : MonoBehaviour

{
    private static ControladorSonidos instance;

    public static ControladorSonidos Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ControladorSonidos>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("ControladorSonidos");
                    instance = obj.AddComponent<ControladorSonidos>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }
    


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
      
    }
    public AudioSource audioSource;
    public AudioClip playerAudio;
    public AudioClip playerJumpAudioClip;
    public void PlayerSound()
    {
        if (!audioSource.isPlaying || audioSource.clip != playerAudio)
        {
        audioSource.clip = playerAudio;
        audioSource.loop = true;
        audioSource.Play();

        }
        

    }
    public void StopPlayerSound()
    {

        audioSource.Stop();
        audioSource.loop=false;
    }

    public void PlayerJump()
    {
        audioSource.PlayOneShot(playerJumpAudioClip);
    }
}