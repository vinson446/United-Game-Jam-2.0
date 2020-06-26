using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBullet : MonoBehaviour
{
    public int damage;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, range);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(damage);

            Destroy(gameObject);
        }
        else if (other.tag != "Player" && other.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
