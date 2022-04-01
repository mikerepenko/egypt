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

    private int currentLevel = 0;
    private float timer;

    private void Start()
    {
        levels[currentLevel].GetComponent<MapLevel>().OnMouseUpAsButton();

        //menuPlay.SetActive(true);
        //currentLevel = PlayerPrefs.GetInt("currentLevel") - 1;

        StartCoroutine(Fun());
    }

    IEnumerator Fun()
    {
        yield return new WaitForSeconds(1f);
        menuPlay.GetComponent<AnimationEventManager>().Play();
    }
}