using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLvL : MonoBehaviour
{
    int currentNomerLvL;

    private void Start()
    {
        if (PlayerPrefs.HasKey("currentLevel"))
        {
            currentNomerLvL = PlayerPrefs.GetInt("currentLevel");
        }
        else
        {
            currentNomerLvL = 1;
            PlayerPrefs.SetInt("currentLevel", currentNomerLvL);
        }

        //PlayerPrefs.DeleteAll();
    }

    public int CurrentLvLReturn()
    {
        return currentNomerLvL;
    }
}