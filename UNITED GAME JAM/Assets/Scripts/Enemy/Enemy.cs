using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int typeOfEnemy;
    public int currentHP = 100;
    public int maxHP = 100;
    public float moveSpeed;

    public int damage;
    public float attackRange;
    public float attackSpeed;
    float nextAttack;
    public float bulletRange;
    public float bulletSpeed;

    [Header("Misc")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint1;
    public Transform bulletSpawnPoint2;
    public float rotationSmoothing;
    
    // references
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
        LookAtPlayer();

        if (Vector3.Distance(transform.position, playerController.transform.position) < attackRange)
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
        navMeshAgent.speed = 0;

        if (Time.time >= nextAttack)
        {
            nextAttack = Time.time + 1 / attackSpeed;

            // only shoots one bullet at a time
            if (typeOfEnemy == 1 || typeOfEnemy == 4)
            {
                GameObject enemyBullet = Instantiate(bulletPrefab, bulletSpawnPoint1.position, Quaternion.identity);

                Rigidbody rb = enemyBullet.GetComponent<Rigidbody>();
                rb.AddForce(bulletSpawnPoint1.transform.forward * bulletSpeed);

                EnemyBullet eb = enemyBullet.GetComponent<EnemyBullet>();
                eb.damage = damage;
                eb.range = bulletRange;
            }
            // shoots two bullets at a time
            else
            {
                // 1
                GameObject enemyBullet1 = Instantiate(bulletPrefab, bulletSpawnPoint1.position, Quaternion.identity);

                Rigidbody rb1 = enemyBullet1.GetComponent<Rigidbody>();
                rb1.AddForce(bulletSpawnPoint1.transform.forward * bulletSpeed);

                EnemyBullet eb1 = enemyBullet1.GetComponent<EnemyBullet>();
                eb1.damage = damage;
                eb1.range = bulletRange;

                // 2
                GameObject enemyBullet2 = Instantiate(bulletPrefab, bulletSpawnPoint2.position, Quaternion.identity);

                Rigidbody rb2 = enemyBullet2.GetComponent<Rigidbody>();
                rb2.AddForce(bulletSpawnPoint2.transform.forward * bulletSpeed);

                EnemyBullet eb2 = enemyBullet2.GetComponent<EnemyBullet>();
                eb2.damage = damage;
                eb2.range = bulletRange;
            }
        }
    }

    void MoveToPlayer()
    {
        navMeshAgent.SetDestination(playerController.transform.position);
        navMeshAgent.speed = moveSpeed;
    }

    void LookAtPlayer()
    {
        Vector3 direction = playerController.transform.position - transform.position;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSmoothing);
    }

    public void TakeDamage(int d)
    {
        // TODO- play hurt animation
        // TODO- play hurt sound effect

        currentHP -= d;

        if (currentHP <= 0)
            Die();
    }

    void Die()
    {
        // TODO- play death animation
        // TODO- play death sound effect

        Destroy(gameObject);
    }
}
