using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool isFlip;
    public void SetSpriteRenderer(SpriteRenderer _sr)
    {
        sr = _sr; 
    }
    public void FlipSprite(float xInput)
    {
        if (xInput < 0 && !isFlip) isFlip = true;
        else if (xInput > 0 && isFlip) isFlip = false;

        sr.flipX = isFlip;
    }
}
