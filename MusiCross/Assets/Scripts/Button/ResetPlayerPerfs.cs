using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPerfs : MonoBehaviour
{
    public void resetAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
