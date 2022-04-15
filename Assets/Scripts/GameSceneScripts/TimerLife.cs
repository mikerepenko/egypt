using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerLife : MonoBehaviour
{
    [SerializeField] ResursScript lifes;
    [SerializeField] Text timerText;
    float time;
    float pastTime;

    bool isReplenishment;
    WWW www;

    private void Start()
    {
        www = new WWW("https://candy-smith.info/gettime.php");

        if (lifes.countResurs < 5)
        {
            if (PlayerPrefs.HasKey("LastTimeLife") && PlayerPrefs.HasKey("PastTime"))
            {
                time = PlayerPrefs.GetFloat("LastTimeLife");
                pastTime = PlayerPrefs.GetFloat("PastTime");
            }
        }
    }

    private void Update()
    {
        if(lifes.countResurs < 5)
        {
            if(time < 900f)
            {
                time += Time.deltaTime;
                timerText.text = time.ToString();
            }
            else
            {
                lifes.countResurs++;
                lifes.textCountResurs.text = lifes.countResurs.ToString();
                time = 0f;
                timerText.text = "";
            }
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("LastTimeLife", time);
    }
}