using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MoveableComponent
{
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;

    private float dashTimeElapsed = 0f;
    private bool canDash = true;
    private bool isDashing = false;
    private Vector3 dashDirection;

    private float xInput, yInput;

    private PlayerAnimationController animationController;
    private PlayerSpriteController spriteController;

    private void Start()
    {
        animationController = GetComponent<PlayerAnimationController>();
        spriteController = GetComponent<PlayerSpriteController>();

        animationController.SetAnimator(anim);
        spriteController.SetSpriteRenderer(sr);
    }
    private void Update()
    {
        if(!isDashing) GetMovementInput();

        animationController.HandleCharacterAnimation(xInput, yInput);
        spriteController.FlipSprite(xInput);
        Move(new Vector3(xInput, yInput).normalized, PlayerManager.Instance.GET_MovementSpeed());
        HandleDash();
    }
    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartDash();   
        }

        if (isDashing)
        {
            Dash();
            dashTimeElapsed += Time.deltaTime;
            if(dashTimeElapsed >= dashDuration)
            {
                EndDash();
            }
        }
    }

    private void EndDash()
    {
        isDashing = false;
        StartCoroutine(DashCooldown());
    }
    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    private void Dash()
    {
        rb.AddForce(dashDirection * dashSpeed, ForceMode2D.Impulse);
    }
    private void StartDash()
    {
        canDash = false;
        isDashing = true;
        dashTimeElapsed = 0f;

        dashDirection = new Vector3(xInput, yInput).normalized;
    }
    private void GetMovementInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    public float XInput() => xInput;
    public float YInput() => yInput;
}
