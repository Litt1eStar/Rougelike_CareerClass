using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator anim;

    public void SetAnimator(Animator _anim)
    {
        this.anim = _anim;
    } 
    public void HandleCharacterAnimation(float xInput, float yInput)
    {
        bool isMoving = xInput != 0 || yInput != 0;
        anim.SetBool("isMoving", isMoving);
    }
}
