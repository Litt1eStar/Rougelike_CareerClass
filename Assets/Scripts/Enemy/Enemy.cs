using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MoveableComponent
{
    [SerializeField] private Transform attackChecker;
    [SerializeField] private float attackRange = 3f;
    [SerializeField] private float movementSpeed = 2f;
    private NavMeshAgent agent;
    private Vector3 destination;

    private EnemyAnimationController animationController;
    private EnemySpriteController spriteController;

    public bool startAttack;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        animationController = GetComponentInChildren<EnemyAnimationController>();
        animationController.SetAnimator(anim);
        animationController.SetOwner(this);

        spriteController = GetComponent<EnemySpriteController>();
        spriteController.SetSpriteRenderer(sr);
    }
    private void Update()
    {
        destination = PlayerManager.Instance.transform.position;
        agent.speed = movementSpeed;
        agent.SetDestination(destination);

        animationController.PlayAnimation("isMoving", true);
        spriteController.HandleSpriteRotation();

        CheckTarget();

        if(startAttack == true && animationController.isAttackComplete == true)
        {
            StartAttack();
        }
    }

    private void StartAttack()
    {
        Debug.Log("Attack");
        agent.isStopped = true;
        animationController.StartAttack();
    }

    public void StopAttack()
    {
        startAttack = false;
        agent.isStopped = false;    
    }
    private void CheckTarget()
    {
        float playerPosX = PlayerManager.Instance.transform.position.x;
        Vector3 direction = playerPosX > transform.position.x ? transform.right : transform.forward;
        RaycastHit2D hit = Physics2D.Raycast(attackChecker.position, direction, attackRange, LayerMask.GetMask("Player"));

        if(hit.collider != null)
        {
            startAttack = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (attackChecker == null || PlayerManager.Instance == null) return;

        float playerPosX = PlayerManager.Instance.transform.position.x;

        float atkRange = playerPosX > transform.position.x ? attackRange : -attackRange;
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.right) * atkRange;
        Gizmos.DrawLine(attackChecker.position, attackChecker.position + direction);
    }

}
