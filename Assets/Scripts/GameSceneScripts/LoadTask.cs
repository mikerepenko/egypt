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
    [SerializeField] ResursScript stars;
    [SerializeField] Image progress;
    [SerializeField] GameObject PrefabButtonTask;
    [SerializeField] TasksObject tasksObject;
    [SerializeField] ShiftBlock shiftBlock;

    Vector3 touchPos;

    private void OnMouseDown()
    {
        touchPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        Vector3 currentPos = Input.mousePosition;

        Debug.Log(Vector3.Distance(currentPos, touchPos));

        if(Vector3.Distance(currentPos, touchPos) < 0.3f)
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
        }
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