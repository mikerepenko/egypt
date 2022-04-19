using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardForTask : MonoBehaviour
{
    [SerializeField] int XP;
    [SerializeField] int cristals;
    [SerializeField] Text XPtext;
    [SerializeField] Text cristalsText;
    [SerializeField] ResursScript stars;
    [SerializeField] ResursScript cristalls;
    [SerializeField] public AllLvL lvl;

    [SerializeField] Image progress;
    [HideInInspector] public ClassTask task;
    [HideInInspector] public SpriteRenderer objectTask;
    [HideInInspector] public ParticSystemObject particleSystem;
    int nomerTask;
    [HideInInspector] public LoadTask loadTask;

    [SerializeField] List<GameObject> completeCurrentGameObjects;
    [SerializeField] List<GameObject> completeShiftGameObjects;
    [SerializeField] List<GameObject> notCompleteCurrentGameObjects;
    [SerializeField] List<GameObject> notCompleteShiftGameObjects;
    [SerializeField] ShiftBlock shiftBlock;

    bool newLvL;

    private void OnEnable()
    {
        newLvL = false;

        stars.ShiftCountResurs(stars.countResurs-1);

        XPtext.text = XP.ToString();
        cristalsText.text = cristals.ToString();
        cristalls.ShiftCountResurs(cristalls.countResurs+cristals);

        int completeTasks = 0;

        for (int i = 0; i < task.tasks.Count; i++)
        {
            if (task.tasks[i] == Progress.completed)
            {
                completeTasks++;
            }
        }

        nomerTask = completeTasks;

        task.tasks[nomerTask] = Progress.completed;
        completeTasks++;

        if (nomerTask + 1 < task.sprites.Count)
        {
            task.tasks[nomerTask + 1] = Progress.open;
        }

        int allTasks = task.tasks.Count;
        
        progress.fillAmount = (float)((float)completeTasks/(float)allTasks);

        if(progress.fillAmount == 1f)
        {
            lvl.ShiftLvL();
            newLvL = true;
        }
    }

    public void ShiftNewLvL()
    {
        if (nomerTask < task.sprites.Count)
        {
            objectTask.sprite = task.sprites[nomerTask];
            //particleSystem.particleSystem.Play();
        }

        if (newLvL)
        {
            shiftBlock.currentBlock = completeCurrentGameObjects;
            shiftBlock.shiftBlock = completeShiftGameObjects;
        }
        else
        {
            shiftBlock.currentBlock = notCompleteCurrentGameObjects;
            shiftBlock.shiftBlock = notCompleteShiftGameObjects;
        }
    }
}