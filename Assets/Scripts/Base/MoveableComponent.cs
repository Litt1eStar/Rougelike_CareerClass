using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableComponent : MonoBehaviour
{
    protected Animator anim;
    protected SpriteRenderer sr;
    protected Rigidbody2D rb;

    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (sr == null)
        {
            Debug.LogWarning("SpriteRenderer Component is Missing");
        }

        if (anim == null)
        {
            Debug.LogWarning("Animator Component is Missing");
        }
    }
    protected void Move(Vector3 direction, float speed)
    {
        rb.velocity = new Vector2(direction.x, direction.y) * speed;
    }
}
