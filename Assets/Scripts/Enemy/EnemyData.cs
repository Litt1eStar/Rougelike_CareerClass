using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : BaseEntity
{
    public float ATTACK_RANGE;
    public float COOLDOWN_AFTER_ATTACK;
    public void SetEnemyData(float _HP,
                             float _DAMAGE,
                             float _ARMOR,
                             float _MOVEMENT_SPEED,
                             float _ATTACK_SPEED,
                             float _ATTACK_RANGE,
                             float _COOLDOWN_AFTER_ATTACK)
    {
        this.HP = _HP;
        this.DAMAGE = _DAMAGE;
        this.ARMOR = _ARMOR;
        this.MOVEMENT_SPEED = _MOVEMENT_SPEED;
        this.ATTACK_SPEED = _ATTACK_SPEED;
        this.ATTACK_RANGE = _ATTACK_RANGE;
        this.COOLDOWN_AFTER_ATTACK = _COOLDOWN_AFTER_ATTACK;
    }

    public void TakeDamage(float _DAMAGE)
    {
        if(this.HP - _DAMAGE > 0)
        {
            this.HP -= _DAMAGE;
        }
        else if (this.HP - _DAMAGE <= 0)
        {
            this.HP = 0;    
        }
    }
}
