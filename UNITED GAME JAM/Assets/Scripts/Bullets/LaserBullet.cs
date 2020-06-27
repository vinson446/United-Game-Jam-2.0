using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    public bool left;
    public int damage;
    public float range;

    LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        Destroy(gameObject, 100);

        RaycastHit hit;
        if (left)
        {
            if (Physics.Raycast(transform.position, GameObject.Find("L Bullet Spawn").transform.forward, out hit))
            {
                if (hit.collider)
                {
                    lr.SetPosition(0, GameObject.Find("L Bullet Spawn").transform.position);
                    lr.SetPosition(1, hit.point);
                }
            }
            else
            {
                lr.SetPosition(0, GameObject.Find("L Bullet Spawn").transform.position);
                Vector3 mouse = Input.mousePosition;
                lr.SetPosition(1, Camera.main.ScreenToWorldPoint(mouse));
                //lr.SetPosition(1, mouse);
            }
        }
        else
        {
            if (Physics.Raycast(transform.position, GameObject.Find("R Bullet Spawn").transform.forward, out hit))
            {
                if (hit.collider)
                {
                    lr.SetPosition(0, GameObject.Find("R Bullet Spawn").transform.position);
                    lr.SetPosition(1, hit.point);
                }
            }
            else
            {
                lr.SetPosition(0, GameObject.Find("R Bullet Spawn").transform.position);
                Vector3 mouse = Input.mousePosition;
                lr.SetPosition(1, Camera.main.ScreenToWorldPoint(mouse));
                //lr.SetPosition(1, mouse);
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {

    }
}
