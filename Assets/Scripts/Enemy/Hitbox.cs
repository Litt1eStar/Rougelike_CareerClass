using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float DAMAGE;

    public void Set_Damage(float val)
    {
        this.DAMAGE = val;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerBaseClass>().playerData.TakeDamage(this.DAMAGE);
        }
    }
}
