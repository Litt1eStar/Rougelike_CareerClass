using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "SO/WeaponSO")]
public class WeaponScriptableObject : ScriptableObject
{
    public Sprite sprite;
    public Bullet WEAPON_BULLET;

    public float DAMAGE;
    public float PROJECTILE_SPEED;
    public float FIRE_RATE;
}
