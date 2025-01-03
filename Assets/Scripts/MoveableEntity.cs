using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableEntity : MonoBehaviour
{
    [SerializeField] protected float movementSpeed = 10f;

    protected Animator anim;
    protected SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();

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
        transform.position += direction * speed * Time.deltaTime;
    }
    public void SET_MovementSpeed(float _movementSpeed)
    {
        this.movementSpeed = _movementSpeed;
    }
}
