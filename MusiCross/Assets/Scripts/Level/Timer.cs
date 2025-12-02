using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Timer : MonoBehaviour
{
    public Text textbox;
    private string time;
    private float seconds, flicker = 0;
    private int minutes;
    private int hours;
    private string zeroForSeconds;
    private string zeroForMinutes;
    private GridSpawner gridSpawner;
    private string scene = "LevelSelect";
    private string sceneName;

    private LookUpTableClipFileName lookUpTableClipFileName;

    // Start is called before the first frame update
    void Start()
    {
        gridSpawner = FindObjectOfType<GridSpawner>();
        sceneName = gameObject.scene.name;
        lookUpTableClipFileName = FindObjectOfType<LookUpTableClipFileName>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gridSpawner.puzzleSolve)
        { // Add Seconds
            seconds += Time.deltaTime;

            // Add Minutes
            if (seconds >= 59.5f) { seconds -= 60f; minutes += 1; }

            // Add Hours
            if (minutes >= 60) { hours++; minutes -= 60; }

            // Edit Time
            if (seconds >= 9.5f) { zeroForSeconds = ""; } else { zeroForSeconds = "0"; }

            if (hours <= 0)
            {
                time = "Time: " + minutes.ToString() + ":" + zeroForSeconds + seconds.ToString("F0");
            }
            else
            {
                if (minutes < 10) { zeroForMinutes = "0"; } else { zeroForMinutes = ""; }
                time = "Time: " + hours.ToString() + ":" + zeroForMinutes + minutes.ToString() + ":" + zeroForSeconds + seconds.ToString("F0");
            }

            // Edit Textbox
            textbox.text = time;
        }
        else
        {
            // Best Time Check
            float floatTime = hours * 60 * 60 + minutes * 60 + seconds;
            if (LevelTimes.getLevelTimeFloat(sceneName) == 0f || LevelTimes.getLevelTimeFloat(sceneName) > floatTime)
            {
                // ReFormat Time To Save to Player Best Times
                time = "";
                time += hours + ":";
                if (minutes < 10) { time += "0" + minutes + ":"; } else { time += minutes + ":"; }
                if (seconds >= 9.5f) { time += seconds.ToString("F0"); } else { time += "0" + seconds.ToString("F0"); }

                // Save Best Time
                LevelTimes.setLevelTime(sceneName, time);
                LevelTimes.setLevelTimeFloat(sceneName, floatTime);
            }




            // Exit To Select Level Scene
            flicker += Time.deltaTime;


            if (flicker >= 2.0) {
                string currentScene = SceneManager.GetActiveScene().name;
                lookUpTableClipFileName.UnlockMusic(currentScene);
                SceneManager.LoadScene(scene);
                
            }

        }
    }
}
