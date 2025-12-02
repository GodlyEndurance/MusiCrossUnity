using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpTableClipFileName : MonoBehaviour
{
    public AudioClip c1, c2, c3, c4, c5;
    private Dictionary<string, AudioClip> audioClipMap = new Dictionary<string, AudioClip>();
    private Dictionary<string, bool> checkMusicUnlocked = new Dictionary<string, bool>();
    private Dictionary<string, string> sceneLinkMusic = new Dictionary<string, string>();
    private int count = 0;

    private const string MUSIC_UNLOCK_PREFIX = "MusicUnlocked_";

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        InitializeAudioClips();
        LoadMusicUnlockStates();
    }

    private void InitializeAudioClips()
    {
        // Clear dictionaries
        audioClipMap.Clear();
        checkMusicUnlocked.Clear();
        sceneLinkMusic.Clear();

        // Add AudioClips to the dictionary
        audioClipMap.Add("title_music", c1);
        audioClipMap.Add("minecraft_music", c2);
        audioClipMap.Add("zelda_music", c3);
        audioClipMap.Add("christmas_music", c4);
        audioClipMap.Add("ff_music", c5);

        // Set default unlock states (will be overwritten by LoadMusicUnlockStates if saved)
        checkMusicUnlocked.Add("title_music", true);  // Default unlocked
        checkMusicUnlocked.Add("minecraft_music", false);
        checkMusicUnlocked.Add("zelda_music", false);
        checkMusicUnlocked.Add("christmas_music", false);
        checkMusicUnlocked.Add("ff_music", false);

        sceneLinkMusic.Add("Level1", "title_music");
        sceneLinkMusic.Add("Level2", "minecraft_music");
        sceneLinkMusic.Add("Level3", "zelda_music");
        sceneLinkMusic.Add("Level4", "christmas_music");
        sceneLinkMusic.Add("Level5", "ff_music");

    }

    public AudioClip GetAudioClip(string clipName)
    {
        if (audioClipMap.ContainsKey(clipName))
        {
            Debug.Log("Hashmap key: " + clipName + "| Hashmap value: " + audioClipMap[clipName]);
            return audioClipMap[clipName];
        }
        else
        {
            Debug.LogWarning($"AudioClip '{clipName}' not found in lookup table!");
            return null;
        }
    }

    public Dictionary<string,bool> GoThroughCheckMusicUnlockedMap()
    {
        return checkMusicUnlocked;
    }


    public bool GetMusicUnlockedOrNot(string clipName)
    {
        bool value = false;
        if (checkMusicUnlocked.ContainsKey(clipName))
        {
            Debug.Log("Hashmap key: " + clipName + "| Hashmap value: " + checkMusicUnlocked[clipName]);

            if (!checkMusicUnlocked[clipName]) { checkMusicUnlocked.Remove(clipName); checkMusicUnlocked.Add(clipName, true); }
            value = checkMusicUnlocked[clipName]; // true or false

            Debug.Log("The music has been unlocked!\n");
            Debug.Log("The music that was unlocked: " + clipName + " |Value: " + checkMusicUnlocked[clipName] + "\n");

        }
        else
        {
            //Debug.LogWarning($"AudioClip '{clipName}' not found in lookup table!");
            //return false;
        }
        return value;
    }

    public void UnlockMusic(string level)
    {
        if (sceneLinkMusic.ContainsKey(level))
        {
            GetMusicUnlockedOrNot(sceneLinkMusic[level]);
        }
        else
        {
            Debug.LogWarning($"level '{level}' not found in lookup table!");
        }
    }


    public bool TryGetAudioClip(string clipName, out AudioClip clip)
    {
        return audioClipMap.TryGetValue(clipName, out clip);
    }

    public void AddAudioClip(string clipName, AudioClip audioClip)
    {
        if (!audioClipMap.ContainsKey(clipName))
        {
            audioClipMap.Add(clipName, audioClip);
        }
        else
        {
            Debug.LogWarning($"AudioClip '{clipName}' already exists in lookup table!");
        }
    }

    public bool isEmptyAudio()
    {
        return audioClipMap.Count == 0;
    }

    public bool isEmptyMusicChecker()
    {
        return checkMusicUnlocked.Count == 0;
    }

    private void LoadMusicUnlockStates()
    {
        // Load saved unlock states for each track
        foreach (string trackName in audioClipMap.Keys)
        {
            string prefKey = MUSIC_UNLOCK_PREFIX + trackName;

            // Check if the key exists in PlayerPrefs
            if (PlayerPrefs.HasKey(prefKey))
            {
                // Load saved state (1 = true, 0 = false)
                bool isUnlocked = PlayerPrefs.GetInt(prefKey, 0) == 1;
                checkMusicUnlocked[trackName] = isUnlocked;
                Debug.Log($"Loaded unlock state for {trackName}: {isUnlocked}");
            }
            else
            {
                // Save default state if not exists
                SaveMusicUnlockState(trackName, checkMusicUnlocked[trackName]);
            }
        }
    }

    private void SaveMusicUnlockState(string trackName, bool isUnlocked)
    {
        string prefKey = MUSIC_UNLOCK_PREFIX + trackName;
        PlayerPrefs.SetInt(prefKey, isUnlocked ? 1 : 0);
        PlayerPrefs.Save(); // Ensure it's written to disk
    }


}
