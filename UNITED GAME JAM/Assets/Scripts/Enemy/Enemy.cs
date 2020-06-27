using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float currentHP;
    public float maxHP = 30f;

    public float moveSpeed = 5f;

    public int damage;
    public Transform attackPoint;
    public float attackRange;
    public float attackSpeed;
    float nextAttack;
    public LayerMask enemyLayers;

    PlayerController playerController;
    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        currentHP = maxHP;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerController.transform.position) < 1)
        {
            Attack();
        }
        else
        {
            MoveToPlayer();
        }
    }

    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
    }

    void MoveToPlayer()
    {
        navMeshAgent.SetDestination(playerController.transform.position);
    }

    public void TakeDamage(int d)
    {
        currentHP -= d;

        if (currentHP <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
