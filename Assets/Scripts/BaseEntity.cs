using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    [SerializeField] protected float HP;
    [SerializeField] protected float MP;
    [SerializeField] protected float DAMAGE;
    [SerializeField] protected float ARMOR;
    [SerializeField] protected float MOVEMENT_SPEED;
    [SerializeField] protected float ATTACK_SPEED;

    public void TakeDamage(float _damage)
    {
        if (this.HP - _damage > 0)
        {
            this.HP -= _damage;
        }
    }

    public float GET_MovementSpeed() => MOVEMENT_SPEED;
}
