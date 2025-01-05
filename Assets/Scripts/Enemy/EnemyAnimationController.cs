using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator anim;
    private EnemyBaseClass owner;
    public bool isAttackComplete = true;
    public void OnAttackComplete()
    {
        StopAttack();
    }
    public void SetOwner(EnemyBaseClass _owner)
    {
        owner = _owner;
    }
    public void SetAnimator(Animator _anim)
    {
        anim = _anim;
    }
    public void StartMoving()
    {
        anim.SetBool(AnimationParams.IsMoving, true);
    }
    public void StartAttack()
    {
        anim.SetBool(AnimationParams.IsAttacking, true);
        anim.SetBool(AnimationParams.IsMoving, false);
        isAttackComplete = false;
    }

    public void StopAttack()
    {
        anim.SetBool(AnimationParams.IsAttacking, false);
        anim.SetBool(AnimationParams.IsMoving, true);
        owner.StopAttack();
        isAttackComplete = true;
    }
}
