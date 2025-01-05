using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator anim;
    private Enemy owner;
    public bool isAttackComplete = true;
    public void OnAttackComplete()
    {
        StopAttack();
    }
    public void SetOwner(Enemy _owner)
    {
        owner = _owner;
    }
    public void SetAnimator(Animator _anim)
    {
        anim = _anim;
    }

    public void PlayAnimation(string name, bool isPlay)
    {
        anim.SetBool(name, isPlay);
    }

    public void StartAttack()
    {
        anim.SetBool("isAttacking", true);
        anim.SetBool("isMoving", false);
        isAttackComplete = false;
    }

    public void StopAttack()
    {
        anim.SetBool("isAttacking", false);
        anim.SetBool("isMoving", true);
        owner.StopAttack();
        isAttackComplete = true;
    }
}
