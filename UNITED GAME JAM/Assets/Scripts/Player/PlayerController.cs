using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public float currentHP;
    public float maxHP = 30f;
    public float moveSpeed = 5f;
    public float projectileSpeed;

    float nextAttack;

    Vector3 moveVelocity;
    Rigidbody rb;

    GunController gunController;
    Upgrades upgrades;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentHP = maxHP;

        gunController = FindObjectOfType<GunController>();
        upgrades = GetComponent<Upgrades>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PerformPlayerMovement();
    }

    private void Update()
    {
        GetPlayerMovement();
        PlayerRotation();

        ChangeWeaponsInput();
        Shoot();
    }

    void GetPlayerMovement()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
    }

    void PerformPlayerMovement()
    {
        rb.velocity = moveVelocity;
    }

    void PlayerRotation()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.green);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    void ChangeWeaponsInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (gunController.typeOfGun - 1 >= 1)
            {
                gunController.SwitchGun(gunController.typeOfGun - 1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (gunController.typeOfGun + 1 <= upgrades.weaponUpgrades)
            {
                gunController.SwitchGun(gunController.typeOfGun + 1);
            }
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= nextAttack)
            {
                print("Shoot");
                nextAttack = Time.time + 1 / gunController.fireRate;

                GameObject leftBulletSpawn = GameObject.FindGameObjectWithTag("Left Bullet Spawn");
                GameObject rightBulletSpawn = GameObject.FindGameObjectWithTag("Right Bullet Spawn");
                GameObject leftBulletObj = Instantiate(gunController.bullets[gunController.typeOfGun - 1], leftBulletSpawn.transform.position, Quaternion.identity);
                GameObject rightBulletObj = Instantiate(gunController.bullets[gunController.typeOfGun - 1], rightBulletSpawn.transform.position, Quaternion.identity);

                Rigidbody leftRb = leftBulletObj.GetComponent<Rigidbody>();
                leftRb.AddForce(leftBulletSpawn.transform.forward * projectileSpeed);
                Rigidbody rightRb = rightBulletObj.GetComponent<Rigidbody>();
                rightRb.AddForce(rightBulletSpawn.transform.forward * projectileSpeed);

                switch (gunController.typeOfGun)
                {
                    // pistol
                    case 1:
                        PistolBullet leftPistolBullet = leftBulletObj.GetComponent<PistolBullet>();
                        leftPistolBullet.damage = gunController.damage;
                        leftPistolBullet.range = gunController.range;

                        PistolBullet rightPistolBullet = rightBulletObj.GetComponent<PistolBullet>();
                        rightPistolBullet.damage = gunController.damage;
                        rightPistolBullet.range = gunController.range;

                        break;
                    // shotgun
                    case 2:
                        ShotgunBullet leftShotgunBullet = leftBulletObj.GetComponent<ShotgunBullet>();
                        leftShotgunBullet.damage = gunController.damage;
                        leftShotgunBullet.range = gunController.range;

                        ShotgunBullet rightShotgunBullet = rightBulletObj.GetComponent<ShotgunBullet>();
                        rightShotgunBullet.damage = gunController.damage;
                        rightShotgunBullet.range = gunController.range;

                        break;
                    // assault rifle
                    case 3:
                        RifleBullet leftRifleBullet = leftBulletObj.GetComponent<RifleBullet>();
                        leftRifleBullet.damage = gunController.damage;
                        leftRifleBullet.range = gunController.range;

                        RifleBullet rightRifleBullet = rightBulletObj.GetComponent<RifleBullet>();
                        rightRifleBullet.damage = gunController.damage;
                        rightRifleBullet.range = gunController.range;

                        break;
                    // grenade launcher
                    case 4:
                        GrenadeBullet leftGrenadeBullet = leftBulletObj.GetComponent<GrenadeBullet>();
                        leftGrenadeBullet.damage = gunController.damage;
                        leftGrenadeBullet.range = gunController.range;

                        GrenadeBullet rightGrenadeBullet = rightBulletObj.GetComponent<GrenadeBullet>();
                        rightGrenadeBullet.damage = gunController.damage;
                        rightGrenadeBullet.range = gunController.range;

                        break;
                    // minigun
                    case 5:
                        MinigunBullet leftMinigunBullet = leftBulletObj.GetComponent<MinigunBullet>();
                        leftMinigunBullet.damage = gunController.damage;
                        leftMinigunBullet.range = gunController.range;

                        MinigunBullet rightMinigunBullet = rightBulletObj.GetComponent<MinigunBullet>();
                        rightMinigunBullet.damage = gunController.damage;
                        rightMinigunBullet.range = gunController.range;

                        break;
                    // laser rifle
                    case 6:
                        LaserBullet leftLaserBullet = leftBulletObj.GetComponent<LaserBullet>();
                        leftLaserBullet.damage = gunController.damage;
                        leftLaserBullet.range = gunController.range;

                        LaserBullet rightLaserBullet = rightBulletObj.GetComponent<LaserBullet>();
                        rightLaserBullet.damage = gunController.damage;
                        rightLaserBullet.range = gunController.range;

                        break;
                }
            }
        }
    }
}
