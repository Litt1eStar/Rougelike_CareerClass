using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float DAMAGE;

    public void Init(float _DAMAGE)
    {
        this.DAMAGE = _DAMAGE;
    }
    public void SetRotationTo(Vector3 target)
    {
        Vector2 direction = (target - transform.position).normalized;   
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyBaseClass enemy = collision.GetComponent<EnemyBaseClass>();
            enemy.enemyData.TakeDamage(this.DAMAGE);
            GameObject.Destroy(this.gameObject);
        }
    }
}
