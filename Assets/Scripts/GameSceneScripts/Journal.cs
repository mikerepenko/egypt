using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    [SerializeField] LoadTask[] allObjects;
    [SerializeField] AllLvL lvL;
    int nomerLvL;

    private void OnEnable()
    {
        /*if (PlayerPrefs.HasKey("currentLevel"))
        {
            //nomerLvL = PlayerPrefs.GetInt("currentLevel");
            nomerLvL = lvL.currentNomerLvL;
        }
        else
        {
            nomerLvL = 1;
        }*/

        nomerLvL = lvL.currentNomerLvL;
        LoadTask currentObject = allObjects[nomerLvL - 1];
        currentObject.LoadTaskBoard(currentObject.dataObject.classTask);
    }
}