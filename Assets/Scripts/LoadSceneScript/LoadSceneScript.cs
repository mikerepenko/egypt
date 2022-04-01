using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneScript : MonoBehaviour
{
    [SerializeField] Image progressBar;
    [SerializeField] GameObject BlockText;
    [SerializeField] GameObject loadBar;
    [SerializeField] GameObject PlayButton;
    [SerializeField] GameObject SettingsButton;

    AsyncOperation loadingSceneOperation;
    float speedLoad;
    bool load;

    private void Start()
    {
        loadingSceneOperation = SceneManager.LoadSceneAsync(NomerShiftScene.nomerScene);
        loadingSceneOperation.allowSceneActivation = false;
        load = true;
        speedLoad = 0.00045f;
    }

    private void Update()
    {
        if (progressBar.fillAmount != 1f)
        {
            /*if (!loadingSceneOperation.isDone && loadingSceneOperation.progress < 0.9f)
            {
                Debug.Log(loadingSceneOperation.progress);
                progressBar.fillAmount = loadingSceneOperation.progress;
            }
            else
            {
                progressBar.fillAmount = 1f;

                BlockText.SetActive(false);

                PlayButton.SetActive(true);
                SettingsButton.SetActive(true);

                load = false;
            }*/

            progressBar.fillAmount += speedLoad;
        }
        else
        {
            BlockText.SetActive(false);
            loadBar.SetActive(false);

            PlayButton.SetActive(true);
            SettingsButton.SetActive(true);
        }
    }

    public void LoadScene()
    {
        //SceneManager.LoadScene(NomerShiftScene.nomerScene);
        if(load && NomerShiftScene.nomerScene == 1)
        {
            PlayButton.SetActive(false);
            SettingsButton.SetActive(false);

            BlockText.SetActive(true);
            loadBar.SetActive(true);

            progressBar.fillAmount = 0f;
            speedLoad *= 2;

            load = false;
        }
        else
        {
            loadingSceneOperation.allowSceneActivation = true;
        }
    }
}