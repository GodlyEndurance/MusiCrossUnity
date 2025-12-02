using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelSelectInfoBars : MonoBehaviour
{
    public Text textbox;
    public string levelNumber;
    public string levelSceneName;

    // Start is called before the first frame update
    void Start()
    {
        string bestTime = LevelTimes.getLevelTime(levelSceneName);
        string completed = "";
        if(bestTime != "NONE") { completed = "★"; }
        textbox.text = "       " + levelNumber + "        |    " + bestTime + "     | " + completed ;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
