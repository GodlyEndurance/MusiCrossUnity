using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MusicManager
{
    public static AudioSource source;
    public static AudioClip clip;
    private static string defaultFile;
    private static string currentFilePlay;

    public static void SetCurrentMusicFile(string musicFileName, LookUpTableClipFileName lookUpTableClipFileName)
    {
        currentFilePlay = musicFileName;

        // Load the audio clip from Resources
        clip = lookUpTableClipFileName.GetAudioClip(musicFileName);


        if (clip == null)
        {
            Debug.LogError($"Could not load audio file: {musicFileName}");
            return;
        }

        // Assign the clip to the audio source
        if (source != null)
        {
            source.clip = clip;
            Debug.Log("The clip was set to: " + clip);
        }
        else
        {
            Debug.LogError("AudioSource is null! Make sure it's assigned.");
        }

    }

    public static void PlayFile()
    {
        if (source == null)
        {
            Debug.LogError("AudioSource is null! Cannot play.");
            return;
        }

        if (source.clip == null)
        {
            Debug.LogError("No audio clip assigned! Call SetCurrentMusicFile first.");
            return;
        }

        // Actually play the audio
           source.Play();
    }

    public static void Initialize(AudioSource audioSource)
    {
        source = audioSource;
        source.playOnAwake = false; // Set this to false to control playback manually
        source.loop = true; // Usually you want music to loop
    }
}
