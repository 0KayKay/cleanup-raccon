using System;
using TMPro;
using Unity.VisualScripting;
using UnityAtoms.BaseAtoms;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TrashItem : MonoBehaviour
{
    
    public FloatConstant forceMagnitude;
    Rigidbody rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Hide Item on Pick up
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    internal void IsPickedUp()
    {
        gameObject.SetActive(false);
    }


    // Move item a bit in random direction
    [ContextMenu("add force tes")]
    internal void IsTossed()
    {
        if (rigidbody.velocity != Vector3.zero)
        {
            return;
        }
        var force = UnityEngine.Random.insideUnitSphere;

        if (force.y<0)
        {
            force.y = -force.y;
        }
        force = force.normalized * forceMagnitude.Value;
        rigidbody.AddForce(force, ForceMode.Impulse);
    }
}