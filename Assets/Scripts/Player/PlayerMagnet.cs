using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    [SerializeField] private float magnetRange = 5f;

    private void Update()
    {
        Magnet();
    }
    private void Magnet()
    {
        Collider2D[] expOnGround = Physics2D.OverlapCircleAll(this.transform.position, magnetRange, LayerMask.GetMask("EXP"));

        if (expOnGround.Length > 0) 
        {
            foreach (var exp in expOnGround)
            {
                exp.GetComponent<Exp>().MoveTo(this.transform.position);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, magnetRange);
    }
}
