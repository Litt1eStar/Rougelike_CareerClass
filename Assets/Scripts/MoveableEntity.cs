using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableEntity : MonoBehaviour
{
    [SerializeField] protected float movementSpeed = 10f;

    protected Animator anim;
    protected SpriteRenderer sr;

    private void Start()
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

    public virtual void FlipCharacter() { }
    public virtual void MoveCharacter() { }
}
