using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MoveableComponent
{
    [SerializeField] private float movementSpeed = 2f;
    private NavMeshAgent agent;
    private Vector3 destination;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        destination = PlayerManager.Instance.transform.position;
        agent.speed = movementSpeed;
        agent.SetDestination(destination);
    }
}
