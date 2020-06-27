using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
        if (other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.TakeDamage(damage);

            Destroy(gameObject);
        }
        else if (other.tag != "Bullet" && other.tag != "Left Bullet Spawn" && other.tag != "Right Bullet Spawn")
        {
            Destroy(gameObject);
        }
    }
}
