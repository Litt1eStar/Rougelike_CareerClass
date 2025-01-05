using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "SO/EnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    public AnimatorController animatorController;

    public float HP;
    public float DAMAGE;
    public float ARMOR;
    public float MOVEMENT_SPEED;
    public float ATTACK_SPEED;
    public float ATTACK_RANGE;
}
