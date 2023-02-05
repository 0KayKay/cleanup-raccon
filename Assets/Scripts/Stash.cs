using System;
using System.Collections.Generic;
using UnityEngine;

internal class Stash : MonoBehaviour
{
    public List<GameObject> trash = new();
    internal void DigUpItem()
    {
        Debug.Log("Here i Am");
        System.Random random = new System.Random();
        int randomIndex = random.Next(trash.Count);

        var p = transform.position;
        p.y +=1;

        var go = Instantiate(trash[randomIndex],p,Quaternion.identity);
        go.GetComponent<TrashItem>().IsTossed();
        Destroy(gameObject);
    }
}