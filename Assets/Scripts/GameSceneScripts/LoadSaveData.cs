using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveData : MonoBehaviour
{
    public ClassTask classTask;

    private void Start()
    {
        if (PlayerPrefs.HasKey(classTask.nameObject))
        {
            classTask = JsonUtility.FromJson<ClassTask>(PlayerPrefs.GetString(classTask.nameObject));
        }

        for(int i = 0; i<classTask.tasks.Count; i++)
        {
            if(classTask.tasks[i] == Progress.open && i != 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = classTask.sprites[i-1];
                break;
            }
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetString(classTask.nameObject, JsonUtility.ToJson(classTask));
    }
}