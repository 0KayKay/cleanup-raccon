using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class Dumpster : MonoBehaviour
{
    public IntConstant numberOfMaxTrash;
    public IntVariable currentTrash;
    private List<TrashItem> tl = new();
    public void AddTrash(TrashItem trash)
    {
        currentTrash.Value++;
        tl.Add(trash);
        currentTrash.Value = tl.Count;
        if (currentTrash.Value >= numberOfMaxTrash.Value)
        {
            Debug.Log("Victory");
        }

    }
}
