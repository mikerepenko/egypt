using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerLife : MonoBehaviour
{
    [SerializeField] ResursScript lifes;
    [SerializeField] Text timerText;

    bool isReplenishment;

    private void Start()
    {
        WWW www = new WWW("https://candy-smith.info/gettime.php");

        if (lifes.countResurs < 5)
        {

        }
    }

    private void Update()
    {
        
    }
}