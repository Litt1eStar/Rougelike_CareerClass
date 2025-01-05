using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseClass : MoveableComponent
{
    [SerializeField] private Transform attackChecker;

    public EnemyData enemyData;
    public EnemyScriptableObject enemySO;

    private NavMeshAgent agent;
    private Vector3 destination;

    private float elapsedAttackTime = 0f;
    private bool canAttack = true;
    private bool startCooldown = false;

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

        spriteController = GetComponentInChildren<EnemySpriteController>();
        spriteController.SetSpriteRenderer(sr);

        if(enemyData != null)
        {
            enemyData.SetEnemyData(
                    enemySO.HP,
                    enemySO.DAMAGE,
                    enemySO.ARMOR,
                    enemySO.MOVEMENT_SPEED,
                    enemySO.ATTACK_SPEED,
                    enemySO.ATTACK_RANGE,
                    enemySO.COOLDOWN_AFTER_ATTACK);

            anim.runtimeAnimatorController = enemySO.animatorController as RuntimeAnimatorController;
            agent.speed = enemyData.MOVEMENT_SPEED;
        }
    }
    private void Update()
    {
        if(PlayerManager.Instance == null) return;

        if (startAttack == true && canAttack == true && animationController.isAttackComplete == true)
        {
            StartAttack();
        }
        else if (!startAttack)
        {
            destination = PlayerManager.Instance.transform.position;
            agent.SetDestination(destination);
            animationController.StartMoving();
        }

        spriteController.HandleSpriteRotation();
        CheckTarget();

        if (startCooldown)
        {
            elapsedAttackTime -= Time.deltaTime;

            if (elapsedAttackTime <= 0f)
            {
                canAttack = true;
                startCooldown = false;
            }
        }
    }

    protected void StartAttack()
    {
        agent.isStopped = true;
        animationController.StartAttack();
        canAttack = false;

        AttackPattern();
    }

    protected virtual void AttackPattern()
    {
        //Used for create collider or gameobject that will use to affect damage to player 
        //Ex. Shoot Particle (bullet, fire ball, etc)
    }

    public void StopAttack()
    {
        startAttack = false;
        agent.isStopped = false;
        startCooldown = true;
        elapsedAttackTime = enemyData.COOLDOWN_AFTER_ATTACK;
    }
    private void CheckTarget()
    {
        float playerPosX = PlayerManager.Instance.transform.position.x;
        Vector3 raycastDirection = playerPosX > transform.position.x ? transform.right : -transform.right;
        RaycastHit2D hit = Physics2D.Raycast(attackChecker.position, raycastDirection, enemyData.ATTACK_RANGE, LayerMask.GetMask("Player"));
        Debug.DrawRay(attackChecker.position, raycastDirection * enemyData.ATTACK_RANGE, Color.red);

        if(hit.collider != null && hit.collider.CompareTag("Player"))
        {
            startAttack = true;
        }
        else
        {
            startAttack = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (attackChecker == null || PlayerManager.Instance == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackChecker.position, enemyData.ATTACK_RANGE);
    }

}
