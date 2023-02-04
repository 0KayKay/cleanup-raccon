using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaccoonScript : MonoBehaviour
{
    public SpriteRenderer playerSprite;

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
}
