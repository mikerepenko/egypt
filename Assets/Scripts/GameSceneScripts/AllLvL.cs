using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllLvL : MonoBehaviour
{
    [SerializeField] Text textLvL;
    [SerializeField] Image progressLvL;
    public int currentNomerLvL;

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

        textLvL.text += currentNomerLvL;

        if (PlayerPrefs.HasKey("progressLvL"))
        {
            progressLvL.fillAmount = PlayerPrefs.GetFloat("progressLvL");
        }

        PlayerPrefs.DeleteAll();
    }

    public void ShiftLvL()
    {
        textLvL.text = "Уровень " + currentNomerLvL;
        progressLvL.fillAmount = 0f;
    }
}