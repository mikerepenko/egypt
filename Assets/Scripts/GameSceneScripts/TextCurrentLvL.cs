using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCurrentLvL : MonoBehaviour
{
    public AllLvL lvl;

    private void OnEnable()
    {
        gameObject.GetComponent<Text>().text = "Уровень " + lvl.CurrentLvLReturn().ToString();
    }
}