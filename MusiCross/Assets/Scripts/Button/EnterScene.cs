using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum ButtonOutput
{
    play,
    titleStart,
    musicDefaultSelect
};

public class EnterScene : MonoBehaviour
{

    public ButtonOutput buttonOutput;
    private ViewHandler ViewHandler;


    MusicDropDown musicDropDown;
    
    
    // Case 1: Default Button Play
    // MusicDropDown: CheckToSeeIfToggleWasAlreadyOn -> if false, then do this
    // NOTE: the button must have its respective song and scene in the inspector panel
    // public MusicFile -> MusicManager.setDefaultMusicFile()

    // Case 2:display of tracks
    // MusicDropDown: CheckToSeeIfToggleWasAlreadyOn -> if true, then do this
    // MusicDropDown: OnNewOptionPicked -> get song name and set the song name for CurrentSongName for MusicManager
    // MusicManager: play -> play the song name


    // PSUEDOCODE
    // MusicDropDown mdd
    // False/Default/ Button w/ toggle off
    // If (!(mdd.CheckToSeeIfToggleWasAlreadyOn())) {button gives MusicManager the music file, via MusicManager.setCurrentMusicFile()}

    // True/Non-default/ Button w/ toggle on
    // else { if (OnNewOptionPicked == "" || OnNewOptionPicked == "NONE"){System print out: "Please select the music you want to use." }
    //        else{Set respective song to currentMusicFile, via MusicManager.setCurrentMusicFile() }
    // }


    public string scene;
    
    public void Enter()
    {
        

        SceneManager.LoadScene(scene);
        // ViewHandler.displayRespectiveView(buttonOutput);

    }


}
