using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text textbox;
    private string time;
    private float seconds;
    private int minutes;
    private int hours;
    private string zeroForSeconds;
    private string zeroForMinutes;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        // Add Seconds
        seconds += Time.deltaTime;

        // Add Minutes
        if(seconds >= 59.5f) { seconds -= 60f; minutes += 1;}

        // Add Hours
        if(minutes >= 60) { hours++; minutes -= 60;}

        // Edit Time
        if(seconds >= 9.5f) { zeroForSeconds = ""; } else { zeroForSeconds = "0"; }

        if(hours <= 0)
        {
            time = "Time: " + minutes.ToString() + ":" + zeroForSeconds + seconds.ToString("F0");
        }
        else
        {
            if(minutes < 10) { zeroForMinutes = "0"; } else { zeroForMinutes = "";}
            time = "Time: " + hours.ToString() + ":" + zeroForMinutes + minutes.ToString() + ":" + zeroForSeconds + seconds.ToString("F0");
        }

        // Edit Textbox
        textbox.text = time;

    }
}
