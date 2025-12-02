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

    void Start()
    {
        InitializeAudioClips();
    }

    private void InitializeAudioClips()
    {
        // Add AudioClips to the dictionary
        //audioClipMap.Add("title_music", Resources.Load<AudioClip>("Music/C418 - Wet Hands.mp3"));
        //audioClipMap.Add("minecraft_music", Resources.Load<AudioClip>("Music/Revenge - A Minecraft Parody of Ushers DJ Got Us Fallin In Love (Music Video).mp3"));

        audioClipMap.Add("title_music", c1 );
        audioClipMap.Add("minecraft_music", c2);

        checkMusicUnlocked.Add("title_music", true);
        checkMusicUnlocked.Add("minecraft_music", false);

        sceneLinkMusic.Add("Level1", "title_music");
        sceneLinkMusic.Add("Level2", "minecraft_music");


        audioClipMap.Add("zelda_music", c3);
        audioClipMap.Add("christmas_music",c4);
        audioClipMap.Add("ff_music",c5);
        // audioClipMap.Add("game_over", Resources.Load<AudioClip>("Audio/game_over"));


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

    public bool isEmpty()
    {
        bool returnValue = false;

        foreach (var item in audioClipMap.Keys) {
            count += 1;
        }

        if (count == 0) { returnValue = true; }

        return returnValue;
    }

}
