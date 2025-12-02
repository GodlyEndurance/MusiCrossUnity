using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinBox : MonoBehaviour
{
    private GridSpawner gridSpawner;
    Image boxImage;
    public Text boxText;
    // Start is called before the first frame update
    void Start()
    {
        gridSpawner = FindObjectOfType<GridSpawner>();
        boxImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        boxImage.enabled = gridSpawner.puzzleSolve;
        boxText.enabled = gridSpawner.puzzleSolve;
        //setactive = gridSpawner.puzzleSolve;
    }
}
