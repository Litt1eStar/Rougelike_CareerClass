using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;

    Animator anim;
    SpriteRenderer sr;
    float xInput;
    float yInput;

    bool isMoving = false;  
    bool isFlip = false;
    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();  

        if(sr == null)
        {
            Debug.LogWarning("SpriteRenderer Component is Missing");
        }

        if (anim == null)
        {
            Debug.LogWarning("Animator Component is Missing");
        }
    }
    private void Update()
    {
        GetMovementInput();
        MoveCharacter();
        FlipCharacter();
        HandleCharacterAnimation();
    }
    private void HandleCharacterAnimation()
    {
        isMoving = xInput != 0 || yInput != 0;
        anim.SetBool("isMoving", isMoving);
    }
    private void FlipCharacter()
    {
        if(xInput < 0 && !isFlip) isFlip = true;
        else if(xInput > 0 && isFlip) isFlip = false;
        sr.flipX = isFlip;
    }
    private void GetMovementInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    private void MoveCharacter()
    {
        transform.position += new Vector3(xInput, yInput).normalized * movementSpeed * Time.deltaTime;
    }
}
