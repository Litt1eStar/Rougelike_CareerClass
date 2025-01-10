using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteController : MonoBehaviour
{
    private SpriteRenderer sr;

    public void SetSpriteRenderer(SpriteRenderer _sr)
    {
        sr = _sr;
    }

    public void HandleSpriteRotation()
    {
        float playerPosX = PlayerManager.Instance.transform.position.x;

        if (playerPosX > transform.position.x)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
