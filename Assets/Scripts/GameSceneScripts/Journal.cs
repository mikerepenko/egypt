using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    [SerializeField] LoadTask[] allObjects;
    int nomerLvL;
    bool kostil;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("currentLevel"))
        {
            nomerLvL = PlayerPrefs.GetInt("currentLevel");
        }
        else
        {
            nomerLvL = 1;
        }

        LoadTask currentObject = allObjects[nomerLvL - 1];
        currentObject.LoadTaskBoard(currentObject.dataObject.classTask);
    }
}