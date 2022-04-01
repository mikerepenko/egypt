using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMethodShiftScene : MonoBehaviour
{
    [SerializeField] int nomer;

    public void ButtonMethod()
    {
        NomerShiftScene.nomerScene = nomer;
        NomerShiftScene.nomerPlayLvL = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }
}