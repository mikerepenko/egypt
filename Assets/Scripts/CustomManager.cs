using SweetSugar.Scripts.GUI;
using SweetSugar.Scripts.MapScripts;
using SweetSugar.Scripts.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPlay;
    [SerializeField] private GameObject[] levels;
    [SerializeField] GameObject panelLoad;

    [SerializeField] int lvl;

    //private int currentLevel = 0;

    private void Start()
    {
        panelLoad.SetActive(true);
        //currentLevel = PlayerPrefs.GetInt("currentLevel") - 1;

        Debug.Log(1);
        levels[lvl].GetComponent<MapLevel>().OnMouseUpAsButton();

        StartCoroutine(Fun());
    }

    IEnumerator Fun()
    {
        yield return new WaitForSeconds(2f);
        menuPlay.GetComponent<AnimationEventManager>().Play();
        yield return new WaitForSeconds(1.5f);
        panelLoad.SetActive(false);
    }
}