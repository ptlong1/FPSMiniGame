using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieAgent : MonoBehaviour
{
	public NavMeshAgent agent;
	public Transform player;
	public Animator animator;
	public LayerMask whatIsGround, whatIsPlayer;

	//Patrolling 
	public Vector3 walkPoint;
	public float walkPointRange;
	bool walkPointSet;
	//Attacking
	public float timeBetweenAttacks;
	bool alreadyAttack;

	//States
	public float sightRange, attackRange;
	public bool playerInSightRange, playerInAttackRange;

	Damage damage;
	
	private void Awake() {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		damage = GetComponent<Damage>();
	}

	private void Update() {
		playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);	
		playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
		if (!playerInAttackRange && !playerInSightRange) Patroling();
		if (playerInSightRange && !playerInAttackRange) Chase();
		if (playerInAttackRange) Attack();
	}
	void Patroling()
	{
		if (!walkPointSet)
		{
			SearchWalkPoint();
		}
		if (walkPointSet)
		{
			agent.SetDestination(walkPoint);
		}
		Vector3 distanceToWalkPoint = transform.position - walkPoint;

		if (distanceToWalkPoint.magnitude < 1f)
		{
			walkPointSet = false;
		}
	}

	private void SearchWalkPoint()
	{
		float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
		float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
		
		walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
		if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
		{
			walkPointSet = true;
		}
	}

	void Chase()
	{
		agent.SetDestination(player.position);
	}

	void Attack()
	{
		agent.SetDestination(transform.position);
		transform.LookAt(player);
		if (!alreadyAttack)
		{
			// attack bla bla
			player.GetComponent<Health>().TakeDamage(damage.damage);
			alreadyAttack = true;
			Invoke(nameof(ResetAttack), timeBetweenAttacks);
		}
	}

	void ResetAttack()
	{
		alreadyAttack = false;
	}
}
