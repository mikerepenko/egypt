using SweetSugar.Scripts.GUI;
using SweetSugar.Scripts.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomManager : MonoBehaviour
{
    [SerializeField] GUIUtils gUIUtils;

    private void Start()
    {
        PlayerPrefs.DeleteAll();

        GUIUtils.THIS = gUIUtils;

        if (GUIUtils.THIS == null)
        {
            Debug.Log(1);
        }

        gUIUtils.DebugSettings = Resources.Load<DebugSettings>("Scriptable/DebugSettings");
        gUIUtils.DebugSettings.AI = true;
        gUIUtils.StartGame();
    }
}