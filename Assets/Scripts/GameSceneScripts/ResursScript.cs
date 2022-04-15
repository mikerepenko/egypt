using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResursScript : MonoBehaviour
{
    [SerializeField] string nameResurs;
    [SerializeField] int startCount;
    [HideInInspector]
    public int countResurs;
    public Text textCountResurs;

    private void Start()
    {
        if (PlayerPrefs.HasKey(nameResurs))
        {
            countResurs = PlayerPrefs.GetInt(nameResurs);
        }
        else
        {
            countResurs = startCount;
            PlayerPrefs.SetInt(nameResurs, countResurs);
        }

        textCountResurs.text = countResurs.ToString();
    }
}