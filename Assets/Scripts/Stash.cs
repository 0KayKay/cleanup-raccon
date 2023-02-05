using System;
using UnityEngine;

internal class Stash : MonoBehaviour
{
    internal void DigUpItem()
    {
        Debug.Log("Here i Am");
        Destroy(gameObject);
    }
}