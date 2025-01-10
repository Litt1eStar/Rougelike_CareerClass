using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : BaseEntity
{
    public int currentLevel = 1;
    public float currentExp = 0f;
    public float maxExp = 10f;

    public float ATTACK_RANGE = 5f;
    public void SetPlayerData(float _HP,
                             float _DAMAGE,
                             float _ARMOR,
                             float _MOVEMENT_SPEED,
                             float _ATTACK_SPEED)
    {
        this.HP = _HP;
        this.DAMAGE = _DAMAGE;
        this.ARMOR = _ARMOR;
        this.MOVEMENT_SPEED = _MOVEMENT_SPEED;
        this.ATTACK_SPEED = _ATTACK_SPEED;
    }

    public override void Die()
    {
        base.Die();

        //EVENT WHEN PLAYER DIE
    }

    public void AddExp(float val)
    {
        if (currentExp + val >= maxExp)
        {
            currentExp += val;
            LevelUp();
        }
        else if (currentExp + val < maxExp)
        {
            currentExp += val;
        }

        UIManager.Instance.OnExpChange(currentExp);
    }

    private void LevelUp()
    {
        currentLevel += 1;
        currentExp = 0;
        maxExp *= 2;
        UIManager.Instance.OnLevelUp(maxExp, currentLevel);
    }
}
