using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "SO/EnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    public AnimatorController animatorController;

    [Header("Enemy Base Stat")]
    public float HP;
    public float DAMAGE;
    public float ARMOR;
    public float MOVEMENT_SPEED;

    [Header("Combat Stat")]
    public float ATTACK_SPEED;
    public float ATTACK_RANGE;
    public float COOLDOWN_AFTER_ATTACK;
}
