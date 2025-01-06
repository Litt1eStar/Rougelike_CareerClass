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
    public float rotationSpeed = 180f; // Degrees per second for smooth rotation

    private Vector3 targetPosition;
    private bool hasTarget = false;

    private void Update()
    {
        AimingTarget();
        if (hasTarget)
        {
            SmoothLookAtTarget();
        }
    }

    public virtual void AimingTarget()
    {
        Collider2D hit = Physics2D.OverlapCircle(PlayerManager.Instance.transform.position, PlayerManager.Instance.ATTACK_RANGE, LayerMask.GetMask("Enemy"));

        if (hit != null)
        {
            targetPosition = hit.transform.position;
            hasTarget = true;

            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
        else
        {
            hasTarget = false;
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
        GameObject projectile = Instantiate(bulletPrefab, projectileGenerator.transform.position, Quaternion.identity);
        Vector2 direction = (targetPosition - projectileGenerator.transform.position).normalized;

        projectile.GetComponent<Bullet>().SetRotationTo(targetPosition);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }

    private void OnDrawGizmos()
    {
        if (PlayerManager.Instance == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(PlayerManager.Instance.transform.position, PlayerManager.Instance.ATTACK_RANGE);
    }
}
