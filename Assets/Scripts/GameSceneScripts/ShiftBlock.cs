using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftBlock : MonoBehaviour
{
    public List<GameObject> currentBlock;
    public List<GameObject> shiftBlock;

    public void Shift()
    {
        if(currentBlock != null)
        {
            for(int i = 0; i<currentBlock.Count; i++)
            {
                currentBlock[i].SetActive(false);
            }
        }

        if (shiftBlock != null)
        {
            for(int i = 0; i<shiftBlock.Count; i++)
            {
                shiftBlock[i].SetActive(true);
            }
        }
    }
}