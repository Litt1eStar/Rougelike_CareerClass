using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectileGenerator;
    public GameObject bulletPrefab;

    public float projectileSpeed = 5f;
    public float fireRate = 1f;
    public float nextFireTime = 0f;

    private Vector3 targetPosition;


    private void Update()
    {
        AimingTarget();
    }
    public virtual void AimingTarget()
    {
        Collider2D hit = Physics2D.OverlapCircle(PlayerManager.Instance.transform.position, PlayerManager.Instance.ATTACK_RANGE, LayerMask.GetMask("Enemy"));

        if (hit != null)
        {
            targetPosition = hit.transform.position;

            if(Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }
    public virtual void Shoot()
    {
        GameObject projectile = Instantiate(bulletPrefab, projectileGenerator.transform.position, Quaternion.identity);
        Vector2 direction = (targetPosition - projectileGenerator.transform.position).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }

    private void OnDrawGizmos()
    {
        if(PlayerManager.Instance == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(PlayerManager.Instance.transform.position, PlayerManager.Instance.ATTACK_RANGE);
    }
}
