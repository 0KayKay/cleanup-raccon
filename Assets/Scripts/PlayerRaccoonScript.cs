using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class PlayerRaccoonScript : MonoBehaviour
{
    public SpriteRenderer playerSprite;
    public List<TrashItem> trashInventory;
    public IntVariable inventoryLimit;

    public bool TryAddTrashToInventory(TrashItem item)
    {
        if (trashInventory.Count < inventoryLimit.Value)
        {
            trashInventory.Add(item);
            item.IsPickedUp();
            return true;
        }
        item.IsTossed();
        return false;
    }

    public bool RemoveTrashFromInventory() {

        if (trashInventory.Count > 0)
        {
            trashInventory.RemoveAt(trashInventory.Count-1);
            return true;
        }
        return false;
    }

    //collect the trash on enter
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "trash")
        {
            var ot = hit.gameObject.GetComponent<TrashItem>();
            TryAddTrashToInventory(ot);
        }
    }

    #region SpriteStuff

    public void FlipSpriteX(bool side)
    {
        playerSprite.flipX = side;
    }
    public void FlipSpriteY(bool side)
    {
        playerSprite.flipX = side;
    }
    internal void FlipSpriteLeft()
    {
        FlipSpriteX(true);
    }

    internal void FlipSpriteRight()
    {
        FlipSpriteX(false);
    }
    #endregion


}
