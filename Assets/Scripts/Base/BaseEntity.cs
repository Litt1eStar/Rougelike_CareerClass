using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    public float HP;
    public float MP;
    public float DAMAGE;
    public float ARMOR;
    public float MOVEMENT_SPEED;
    public float ATTACK_SPEED;

    public virtual void TakeDamage(float _DAMAGE)
    {
        if (this.HP - _DAMAGE > 0)
        {
            this.HP -= _DAMAGE;
        }
        else if (this.HP - _DAMAGE <= 0)
        {
            this.HP = 0;
            Die();
        }
    }

    public virtual void Die() 
    {
        Destroy(this.gameObject);
    }
}
