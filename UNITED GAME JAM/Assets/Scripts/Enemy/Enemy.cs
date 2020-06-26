using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHP;
    public float maxHP = 30f;

    public float moveSpeed = 5f;

    public int damage;

    public float attackSpeed;
    float nextAttack;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;   
    }

    // Update is called once per frame
    void Update()
    {
        
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
