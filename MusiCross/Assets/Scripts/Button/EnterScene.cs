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
    

    public string scene;
    
    public void Enter()
    {
        ViewHandler.displayRespectiveView(buttonOutput);
        
    }


}
