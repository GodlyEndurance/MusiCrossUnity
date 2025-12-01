using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicDropdown : MonoBehaviour
{
    public Dropdown dropdown;
    public Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        CheckToSeeIfToggleWasAlreadyOn();
        // YOU CAN USE AddSong() TO ADD UNLOCKED SONGS TO DROPBAR WHEN THE LEVEL SELECTOR SCENE LOADS - MB
        // *** ONLY PROBLEM IS WE PROBABLY NEED A WAY TO FIGURE OUT WHEN A LEVEL IS BEAT ***

        // Dropdown music add
        dropdown.options.Add(new Dropdown.OptionData("Something"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Dropdown Stuff
    public string OnNewOptionPicked()
    {
        string selectedSong = "";
        selectedSong = dropdown.options[dropdown.value].text;
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
