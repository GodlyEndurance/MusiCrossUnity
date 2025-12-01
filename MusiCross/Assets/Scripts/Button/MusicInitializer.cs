using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInitializer : MonoBehaviour
{
    void Start()
    {
        // Get or create AudioSource
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Initialize the MusicManager
        MusicManager.Initialize(audioSource);

        // Make this object persist between scenes if you want continuous music
        DontDestroyOnLoad(gameObject);
    }
}
