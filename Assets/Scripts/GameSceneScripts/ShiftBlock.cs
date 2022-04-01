using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftBlock : MonoBehaviour
{
    [SerializeField] GameObject currentBlock;
    [SerializeField] GameObject shiftBlock;

    public void Shift()
    {
        if(currentBlock != null)
        {
            currentBlock.SetActive(false);
        }

        if (shiftBlock != null)
        {
            shiftBlock.SetActive(true);
        }
    }
}