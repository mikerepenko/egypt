using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedEnergy : MonoBehaviour
{
    [SerializeField] ResursScript energy;
    [SerializeField] ShiftBlock shiftBlock;

    public void NeedEnegyShift()
    {
        if (energy.countResurs < 5)
        {
            shiftBlock.Shift();
        }
    }
}