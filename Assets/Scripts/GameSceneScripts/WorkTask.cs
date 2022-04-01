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
    public int nomerTask;

    public TasksObject tasksObject;
    public ShiftBlock shiftBlock;

    public void ClickButton()
    {
        if (!tasksObject.tasks[nomerTask])
        {
            if (stars.countResurs > 0)
            {
                stars.countResurs--;
                stars.textCountResurs.text = stars.countResurs.ToString();

                int newCountOk = 0;

                for(int i = 0; i<tasksObject.tasks.Count; i++)
                {
                    if (tasksObject.tasks[i])
                    {
                        newCountOk++;
                    }
                }

                progress.fillAmount = (float)((float)newCountOk / tasksObject.tasks.Count);
            }
            else
            {
                shiftBlock.Shift();
            }
        }
    }
}