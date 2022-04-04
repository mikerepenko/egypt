using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClassTask 
{
    public List<Progress> tasks;
    public List<string> nameTasks;
    public List<Sprite> sprites;

    public string nameObject;

    public void Save()
    {
        PlayerPrefs.SetString(nameObject, JsonUtility.ToJson(this));
    }
}

public enum Progress { completed, open, close}