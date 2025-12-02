using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicDropdown : MonoBehaviour
{
    public Dropdown dropdown;
    public Toggle toggle;
    LookUpTableClipFileName lookUpTableClipFileName;

    private static string previousSong = "";

    // Start is called before the first frame update


    void Start()
    {
        lookUpTableClipFileName = FindObjectOfType<LookUpTableClipFileName>();

        CheckToSeeIfToggleWasAlreadyOn();
        // YOU CAN USE AddSong() TO ADD UNLOCKED SONGS TO DROPBAR WHEN THE LEVEL SELECTOR SCENE LOADS - MB
        // *** ONLY PROBLEM IS WE PROBABLY NEED A WAY TO FIGURE OUT WHEN A LEVEL IS BEAT ***

        // Dropdown music add
        dropdown.ClearOptions();

        // Add options
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>
        {
        //new Dropdown.OptionData("title_music"),
        //new Dropdown.OptionData("minecraft_music")
        // Add more options here as needed


        };

        if (lookUpTableClipFileName.isEmptyMusicChecker()) { Debug.LogError("The music checker hashmap is null. \n"); }
        foreach (var item in lookUpTableClipFileName.GoThroughCheckMusicUnlockedMap().Keys)
        {
            Debug.Log("This if statement is about to run. \n");
            if (lookUpTableClipFileName.GoThroughCheckMusicUnlockedMap()[item] == true)
            {
                Debug.Log("Adding something to the dropdown: " + item);
                options.Add(new Dropdown.OptionData(item));
                Debug.Log("The checker for unlocked music to display in the dropdown list ran. \n");
            }
        }


        // Makes sure that the music tracks are unique, and that there are not duplicate tracks in the dropdown list.
        List<Dropdown.OptionData> optionsFinal = new List<Dropdown.OptionData> { };

        if (options.Count == 0)
        {
            Debug.LogWarning("No unlocked music tracks found! Adding default 'None' option.");
            optionsFinal.Add(new Dropdown.OptionData("None"));
        }

        else if (!string.IsNullOrEmpty(previousSong))
        {
            Debug.Log(("The if statement of MusicDropdown:Start() ran. \n"));
            optionsFinal.Add(new Dropdown.OptionData(previousSong));
            foreach (Dropdown.OptionData item in options)
            {
                if (item.text != previousSong)
                {
                    optionsFinal.Add(item);
                }
            }
        }
        else
        {
            Debug.Log(("The else statement of MusicDropdown:Start() ran. \n"));
            foreach (Dropdown.OptionData item in options)
            {
                if (new Dropdown.OptionData(previousSong).text == item.text) { continue; }
                optionsFinal.Add(item);
            }
        }

        Debug.Log(("\nValue of previousSong: " + previousSong + "\n"));


        dropdown.AddOptions(optionsFinal);

        CheckToSeeIfToggleWasAlreadyOn();


        if (dropdown.options.Count > 0)
        {
            dropdown.value = 0;
            dropdown.RefreshShownValue();
        }
        else
        {
            Debug.LogError("Dropdown has no options after all processing!");
            dropdown.interactable = false;
        }


        Debug.Log(("MusicDropdown ran! "));
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Dropdown Stuff
    public void triggerForDropdown() { OnNewOptionPicked(); }

    public string OnNewOptionPicked()
    {
        string selectedSong = "";
        selectedSong = dropdown.options[dropdown.value].text;
        Debug.Log(("OnNewOptionPicked ran! "));
        Debug.Log(("Text: " + selectedSong + "\n"));
        previousSong = selectedSong;

        return selectedSong;
    }

    void AddOption(string option)
    {
        dropdown.options.Add(new Dropdown.OptionData(option));
    }

    // Toggle Stuff
    public void OnToggle()
    {
        if (toggle.isOn)
        {
            dropdown.interactable = true;
            PlayerPrefs.SetInt("CustomMusic", 1);
        }
        else
        {
            dropdown.interactable = false;
            PlayerPrefs.SetInt("CustomMusic", 0);
        }
    }

    public bool CheckToSeeIfToggleWasAlreadyOn()
    {
        bool returnValue = false;
        if (PlayerPrefs.GetInt("CustomMusic") == 1) { toggle.isOn = true; returnValue = true; };
        return returnValue;
    }

}
