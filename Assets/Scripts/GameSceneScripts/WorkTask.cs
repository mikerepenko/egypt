using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkTask : MonoBehaviour
{
    [HideInInspector]
    public ResursScript stars;
    [HideInInspector]
    public Image progress;
    [HideInInspector]
    public Image lvlProgress;
    [HideInInspector]
    public AllLvL lvl;
    [HideInInspector]
    public int nomerTask;
    [HideInInspector]
    public LoadTask loadTask;
    [HideInInspector]
    public ParticSystemObject particSystem;
    [HideInInspector]
    public GameObject taskBoard;

    public ClassTask tasksObject;
    public SpriteRenderer objectTask;
    public ShiftBlock shiftBlock;

    public void ClickButton()
    {
        if (tasksObject.tasks[nomerTask] == Progress.open)
        {
            if (stars.countResurs > 0)
            {
                tasksObject.tasks[nomerTask] = Progress.completed;
                objectTask.sprite = tasksObject.sprites[nomerTask];

                particSystem.StartCoroutine(particSystem.TimePart());

                Debug.Log(2);

                stars.countResurs--;
                stars.textCountResurs.text = stars.countResurs.ToString();

                if(nomerTask + 1 < tasksObject.tasks.Count)
                {
                    tasksObject.tasks[nomerTask + 1] = Progress.open;
                }

                int newCountOk = 0;

                for(int i = 0; i<tasksObject.tasks.Count; i++)
                {
                    if (tasksObject.tasks[i] == Progress.completed)
                    {
                        newCountOk++;
                    }
                }

                progress.fillAmount = (float)((float)newCountOk / tasksObject.tasks.Count);
                lvlProgress.fillAmount = progress.fillAmount;

                if (lvlProgress.fillAmount == 1f)
                {
                    lvl.currentNomerLvL++;
                    lvl.ShiftLvL();

                    PlayerPrefs.SetInt("currentLevel", lvl.currentNomerLvL);
                }

                PlayerPrefs.SetFloat("progressLvL", lvlProgress.fillAmount);
                tasksObject.Save();

                loadTask.LoadTaskBoard(tasksObject);
                taskBoard.SetActive(false);
            }
            else
            {
                shiftBlock.Shift();
            }
        }
    }
}