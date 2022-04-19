using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedResursScript : MonoBehaviour
{
    public ResursScript resurs;
    public ShiftBlock shiftBlock;

    public List<GameObject> resursHaveObjectsCurrent;
    public List<GameObject> resursHaveObjectsShift;

    public List<GameObject> resursNotObjectsCurrent;
    public List<GameObject> resursNotObjectsShift;

    public void NeedActivation()
    {
        if (!(resurs.countResurs <= 0))
        {
            shiftBlock.currentBlock = resursHaveObjectsCurrent;
            shiftBlock.shiftBlock = resursHaveObjectsShift;
        }
        else
        {
            shiftBlock.currentBlock = resursNotObjectsCurrent;
            shiftBlock.shiftBlock = resursNotObjectsShift;
        }

        shiftBlock.Shift();
    }
}