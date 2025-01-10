using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponScriptableObject weaponSO;
    public GameObject projectileGenerator;

    private float nextFireTime = 0f;
    private Vector3 targetPosition;
    private void Start()
    {
        OnEnterUsingWeapon();
    }
    private void Update()
    {
        AimingTarget();
        SmoothLookAtTarget();
    }

    public virtual void AimingTarget()
    {
        Collider2D hit = Physics2D.OverlapCircle(
            PlayerManager.Instance.transform.position,
            PlayerManager.Instance.currentPlayer.playerData.ATTACK_RANGE,
            LayerMask.GetMask("Enemy")
            );

        if (hit != null)
        {
            targetPosition = hit.transform.position;

            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + weaponSO.FIRE_RATE;
            }
        }
    }

    private void SmoothLookAtTarget()
    {
        bool isTargetOnLeft = targetPosition.x < transform.position.x;
        float yRotation = isTargetOnLeft ? 180f : 0f;
        transform.localRotation = Quaternion.Euler(0, yRotation, 0);

        Vector2 direction = (targetPosition - transform.position).normalized;

        float targetAngle = Mathf.Clamp(Mathf.Atan2(direction.y, Mathf.Abs(direction.x)) * Mathf.Rad2Deg, -90, 90); 
        transform.rotation = Quaternion.Euler(0, yRotation, targetAngle);
    }

    public virtual void Shoot()
    {
        GameObject projectile = Instantiate(weaponSO.WEAPON_BULLET.gameObject, projectileGenerator.transform.position, Quaternion.identity);
        Vector2 direction = (targetPosition - projectileGenerator.transform.position).normalized;
        
        projectile.GetComponent<Rigidbody2D>().velocity = direction * weaponSO.PROJECTILE_SPEED;
        Bullet bullet = projectile.GetComponent<Bullet>();
        bullet.Init(weaponSO.DAMAGE);
        bullet.SetRotationTo(targetPosition);
    }

    private void OnDrawGizmos()
    {
        if (PlayerManager.Instance == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(PlayerManager.Instance.transform.position, PlayerManager.Instance.currentPlayer.playerData.ATTACK_RANGE);
    }

    public void OnEnterUsingWeapon()
    {
        //This method will got executed when player start using weapon
        //Ex. Player buy new Weapon from shop and Player use this weapon in game
        GetComponentInChildren<SpriteRenderer>().sprite = weaponSO.sprite;
    }
}
