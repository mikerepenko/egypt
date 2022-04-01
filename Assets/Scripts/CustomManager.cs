using SweetSugar.Scripts.GUI;
using SweetSugar.Scripts.MapScripts;
using SweetSugar.Scripts.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomManager : MonoBehaviour
{
    [SerializeField] MapLevel map;

    private void Awake()
    {
        //Debug.Log(1);
        //map.Fun();
        //Debug.Log(2);
    }

    IEnumerator Fun()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log(1);
    }

    private void Start()
    {
        StartCoroutine(Fun());
    }
}