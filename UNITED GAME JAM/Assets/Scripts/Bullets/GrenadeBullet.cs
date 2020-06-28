using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    public int damage;
    public float range;
    public float explosionRange=5f;
    public GameObject explossionEffect;
    float gernadeTimmer=5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, range);
    }

    // Update is called once per frame
    void Update()
    {
        gernadeTimmer -= Time.deltaTime;
        if (gernadeTimmer <= 0)
            Explode();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(damage);

            Explode();
        }
        else if (other.tag != "Player" && other.tag != "Bullet" && other.tag != "Left Bullet Spawn" && other.tag != "Right Bullet Spawn")
        {
            Explode();
        }

    }

    void Explode()
    {
        Debug.Log("BOMB GO BOOM");
        Collider[] explosionZone = Physics.OverlapSphere(transform.position, explosionRange);
        foreach(Collider nearByChar in explosionZone)
        {
            if (nearByChar.tag == "Enemy" )
            {
                Enemy enemy = nearByChar.GetComponent<Enemy>();
                enemy.TakeDamage(damage);
            }
            if (nearByChar.tag == "Player")
            {
                PlayerController player = nearByChar.GetComponent<PlayerController>();
                player.TakeDamage(damage);
            }
        }
        GameObject boom = Instantiate(explossionEffect, transform.position,transform.rotation);
        Destroy(boom, 2f);
        Destroy(gameObject);
    }
}
