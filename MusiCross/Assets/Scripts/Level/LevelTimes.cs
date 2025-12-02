using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelTimes
{
    public static void setLevelTime(string level, string time)
    {
        PlayerPrefs.SetString(level + "BestTime", time);
    }

    public static string getLevelTime(string level)
    {
        return PlayerPrefs.GetString(level + "BestTime", "NONE");
    }

    public static void setLevelTimeFloat(string level, float time)
    {
        PlayerPrefs.SetFloat(level + "BestTimeFloat", time);
    }

    public static float getLevelTimeFloat(string level)
    {
        return PlayerPrefs.GetFloat(level + "BestTimeFloat", 0f);
    }
}
