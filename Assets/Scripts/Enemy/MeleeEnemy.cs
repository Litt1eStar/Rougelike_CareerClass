using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyBaseClass
{
    public GameObject attackHitbox;
    public Transform attackArea;
    protected override void AttackPattern()
    {
        base.AttackPattern();

        GameObject m_hitbox = Instantiate(attackHitbox, attackArea);
        MeleeHitbox hitbox = m_hitbox.GetComponent<MeleeHitbox>();
        if (hitbox != null) hitbox.Set_Damage(10);
        Destroy(m_hitbox, 0.5f);
    }
}
