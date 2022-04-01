using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    Animator animator;
    bool open;

    private void Start()
    {
        animator = GetComponent<Animator>();
        open = false;
    }

    public void Click()
    {
        if (!open)
        {
            animator.SetTrigger("StartSetting");
            open = true;
        }
        else
        {
            animator.SetTrigger("EndSetting");
            open = false;
        }
    }
}