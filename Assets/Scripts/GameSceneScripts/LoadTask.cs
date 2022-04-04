using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoadTask : MonoBehaviour
{
    [SerializeField] GameObject TaskBoard;
    [SerializeField] GameObject BoardStartGame;
    [SerializeField] GameObject CloseObject;
    [SerializeField] ResursScript stars;
    [SerializeField] Image progress;
    [SerializeField] GameObject PrefabButtonTask;
    [SerializeField] LoadSaveData dataObject;
    [SerializeField] ShiftBlock shiftBlock;

    [SerializeField] AllLvL lvL;
    [SerializeField] int needLvL;
    [SerializeField] Image progressLvL;

    Vector3 touchPos;

    private void OnMouseDown()
    {
        touchPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        Vector3 currentPos = Input.mousePosition;
        ClassTask currentTask = dataObject.classTask;

        if(Vector3.Distance(currentPos, touchPos) < 0.3f)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (needLvL > lvL.currentNomerLvL)
                {
                    CloseObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Заблокировано, откроется на уровне " + needLvL;
                    CloseObject.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = currentTask.sprites[currentTask.sprites.Count - 1];
                    CloseObject.SetActive(true);
                }
                else
                {
                    LoadTaskBoard(currentTask);
                }
            }
        }
    }

    public void LoadTaskBoard(ClassTask currentTask)
    {
        TaskBoard.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = currentTask.nameObject;

        for (int i = 0; i < TaskBoard.transform.GetChild(0).GetChild(0).childCount; i++)
        {
            Destroy(TaskBoard.transform.GetChild(0).GetChild(0).GetChild(i).gameObject);
        }

        TaskBoard.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Image>().sprite = currentTask.sprites[currentTask.sprites.Count - 1];

        Transform position = TaskBoard.transform.GetChild(0).GetChild(0);
        int checkOk = 0;

        for (int i = 0; i < currentTask.nameTasks.Count; i++)
        {
            GameObject newButtonTask = Instantiate(PrefabButtonTask, position);

            newButtonTask.transform.GetChild(1).gameObject.GetComponent<Text>().text = currentTask.nameTasks[i];
            WorkTask work = newButtonTask.transform.GetChild(0).gameObject.GetComponent<WorkTask>();
            work.nomerTask = i;
            work.stars = stars;
            work.progress = progress;
            work.lvlProgress = progressLvL;
            work.lvl = lvL;
            work.tasksObject = currentTask;
            work.objectTask = gameObject.GetComponent<SpriteRenderer>();
            work.shiftBlock.currentBlock = TaskBoard;
            work.shiftBlock.shiftBlock = BoardStartGame;
            work.loadTask = this;

            if (currentTask.tasks[i] == Progress.completed)
            {
                checkOk++;
                newButtonTask.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.green;
            }
            else if (currentTask.tasks[i] == Progress.open)
            {
                newButtonTask.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.yellow;
            }
            else if (currentTask.tasks[i] == Progress.close)
            {
                newButtonTask.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.black;
            }
        }

        progress.fillAmount = (float)((float)checkOk / currentTask.tasks.Count);

        shiftBlock.Shift();
    }

    /*private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            TaskBoard.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = tasksObject.nameObject;

            for (int i = 0; i < TaskBoard.transform.GetChild(0).GetChild(0).childCount; i++)
            {
                Destroy(TaskBoard.transform.GetChild(0).GetChild(0).GetChild(i).gameObject);
            }

            if (PlayerPrefs.HasKey(tasksObject.nameObject))
            {
                tasksObject = JsonUtility.FromJson<TasksObject>(PlayerPrefs.GetString(tasksObject.nameObject));
            }

            Transform position = TaskBoard.transform.GetChild(0).GetChild(0);
            int checkOk = 0;

            for (int i = 0; i < tasksObject.tasks.Count; i++)
            {
                GameObject newButtonTask = Instantiate(PrefabButtonTask, position);

                newButtonTask.transform.GetChild(1).gameObject.GetComponent<Text>().text = tasksObject.nameTasks[i];
                WorkTask work = newButtonTask.transform.GetChild(0).gameObject.GetComponent<WorkTask>();
                work.nomerTask = i;
                work.stars = stars;
                work.progress = progress;
                work.tasksObject = tasksObject;
                work.shiftBlock.currentBlock = TaskBoard;
                work.shiftBlock.shiftBlock = BoardStartGame;

                Debug.Log(tasksObject.tasks[i]);

                if (tasksObject.tasks[i])
                {
                    checkOk++;
                }
            }

            progress.fillAmount = (float)((float)checkOk / tasksObject.tasks.Count);

            shiftBlock.Shift();
        }
    }*/
}