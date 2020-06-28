using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public int currentHP;
    public int maxHP;
    public float moveSpeed = 5f;
    public float projectileSpeed;

    float nextAttack;

    Vector3 moveVelocity;
    Rigidbody rb;

    GunController gunController;
    Upgrades upgrades;

    [Header("UI")]
    public Slider hpBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentHP = maxHP;
        hpBar.maxValue = maxHP;
        hpBar.value = currentHP;

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
                nextAttack = Time.time + 1 / gunController.fireRate;

                GameObject leftBulletSpawn = GameObject.FindGameObjectWithTag("Left Bullet Spawn");
                GameObject rightBulletSpawn = GameObject.FindGameObjectWithTag("Right Bullet Spawn");

                switch (gunController.typeOfGun)
                {
                    // pistol
                    case 1:
                        GameObject leftBulletObj1 = Instantiate(gunController.bullets[gunController.typeOfGun - 1], leftBulletSpawn.transform.position, Quaternion.identity);
                        GameObject rightBulletObj1 = Instantiate(gunController.bullets[gunController.typeOfGun - 1], rightBulletSpawn.transform.position, Quaternion.identity);

                        PistolBullet leftPistolBullet = leftBulletObj1.GetComponent<PistolBullet>();
                        leftPistolBullet.damage = gunController.damage;
                        leftPistolBullet.range = gunController.range;

                        PistolBullet rightPistolBullet = rightBulletObj1.GetComponent<PistolBullet>();
                        rightPistolBullet.damage = gunController.damage;
                        rightPistolBullet.range = gunController.range;

                        Rigidbody leftRb1 = leftBulletObj1.GetComponent<Rigidbody>();
                        leftRb1.AddForce(leftBulletSpawn.transform.forward * projectileSpeed);
                        Rigidbody rightRb1 = rightBulletObj1.GetComponent<Rigidbody>();
                        rightRb1.AddForce(rightBulletSpawn.transform.forward * projectileSpeed);

                        break;
                    // shotgun
                    case 2:
                        GameObject leftBulletObj2 = Instantiate(gunController.bullets[gunController.typeOfGun - 1], leftBulletSpawn.transform.position, Quaternion.identity);
                        GameObject rightBulletObj2 = Instantiate(gunController.bullets[gunController.typeOfGun - 1], rightBulletSpawn.transform.position, Quaternion.identity);

                        ShotgunBullet leftShotgunBullet = leftBulletObj2.GetComponent<ShotgunBullet>();
                        leftShotgunBullet.damage = gunController.damage;
                        leftShotgunBullet.range = gunController.range;

                        ShotgunBullet rightShotgunBullet = rightBulletObj2.GetComponent<ShotgunBullet>();
                        rightShotgunBullet.damage = gunController.damage;
                        rightShotgunBullet.range = gunController.range;

                        Rigidbody leftRb2 = leftBulletObj2.GetComponent<Rigidbody>();
                        leftRb2.AddForce(leftBulletSpawn.transform.forward * projectileSpeed);
                        Rigidbody rightRb2 = rightBulletObj2.GetComponent<Rigidbody>();
                        rightRb2.AddForce(rightBulletSpawn.transform.forward * projectileSpeed);

                        break;
                    // assault rifle
                    case 3:
                        GameObject leftBulletObj3 = Instantiate(gunController.bullets[gunController.typeOfGun - 1], leftBulletSpawn.transform.position, Quaternion.identity);
                        GameObject rightBulletObj3 = Instantiate(gunController.bullets[gunController.typeOfGun - 1], rightBulletSpawn.transform.position, Quaternion.identity);

                        RifleBullet leftRifleBullet = leftBulletObj3.GetComponent<RifleBullet>();
                        leftRifleBullet.damage = gunController.damage;
                        leftRifleBullet.range = gunController.range;

                        RifleBullet rightRifleBullet = rightBulletObj3.GetComponent<RifleBullet>();
                        rightRifleBullet.damage = gunController.damage;
                        rightRifleBullet.range = gunController.range;

                        Rigidbody leftRb3 = leftBulletObj3.GetComponent<Rigidbody>();
                        leftRb3.AddForce(leftBulletSpawn.transform.forward * projectileSpeed);
                        Rigidbody rightRb3 = rightBulletObj3.GetComponent<Rigidbody>();
                        rightRb3.AddForce(rightBulletSpawn.transform.forward * projectileSpeed);

                        break;
                    // grenade launcher
                    case 4:
                        GameObject leftBulletObj4 = Instantiate(gunController.bullets[gunController.typeOfGun - 1], leftBulletSpawn.transform.position, Quaternion.identity);
                        GameObject rightBulletObj4 = Instantiate(gunController.bullets[gunController.typeOfGun - 1], rightBulletSpawn.transform.position, Quaternion.identity);

                        GrenadeBullet leftGrenadeBullet = leftBulletObj4.GetComponent<GrenadeBullet>();
                        leftGrenadeBullet.damage = gunController.damage;
                        leftGrenadeBullet.range = gunController.range;

                        GrenadeBullet rightGrenadeBullet = rightBulletObj4.GetComponent<GrenadeBullet>();
                        rightGrenadeBullet.damage = gunController.damage;
                        rightGrenadeBullet.range = gunController.range;

                        Rigidbody leftRb4 = leftBulletObj4.GetComponent<Rigidbody>();
                        leftRb4.AddForce(leftBulletSpawn.transform.forward * projectileSpeed);
                        Rigidbody rightRb4 = rightBulletObj4.GetComponent<Rigidbody>();
                        rightRb4.AddForce(rightBulletSpawn.transform.forward * projectileSpeed);

                        break;
                    // minigun
                    case 5:
                        GameObject leftBulletObj5 = Instantiate(gunController.bullets[gunController.typeOfGun - 1], leftBulletSpawn.transform.position, Quaternion.identity);
                        GameObject rightBulletObj5 = Instantiate(gunController.bullets[gunController.typeOfGun - 1], rightBulletSpawn.transform.position, Quaternion.identity);

                        MinigunBullet leftMinigunBullet = leftBulletObj5.GetComponent<MinigunBullet>();
                        leftMinigunBullet.damage = gunController.damage;
                        leftMinigunBullet.range = gunController.range;

                        MinigunBullet rightMinigunBullet = rightBulletObj5.GetComponent<MinigunBullet>();
                        rightMinigunBullet.damage = gunController.damage;
                        rightMinigunBullet.range = gunController.range;

                        Rigidbody leftRb5 = leftBulletObj5.GetComponent<Rigidbody>();
                        leftRb5.AddForce(leftBulletSpawn.transform.forward * projectileSpeed);
                        Rigidbody rightRb5 = rightBulletObj5.GetComponent<Rigidbody>();
                        rightRb5.AddForce(rightBulletSpawn.transform.forward * projectileSpeed);

                        break;
                    // laser rifle
                    case 6:
                        GameObject leftBulletObj6 = Instantiate(gunController.bullets[gunController.typeOfGun - 1], Vector3.zero, Quaternion.identity);
                        GameObject rightBulletObj6 = Instantiate(gunController.bullets[gunController.typeOfGun - 1], Vector3.zero, Quaternion.identity);
                        //leftBulletObj6.transform.parent = GameObject.Find("L Bullet Spawn").transform;
                        //rightBulletObj6.transform.parent = GameObject.Find("R Bullet Spawn").transform;

                        LaserBullet leftLaserBullet = leftBulletObj6.GetComponentInChildren<LaserBullet>();
                        leftLaserBullet.left = true;
                        leftLaserBullet.damage = gunController.damage;
                        leftLaserBullet.range = gunController.range;

                        LaserBullet rightLaserBullet = rightBulletObj6.GetComponentInChildren<LaserBullet>();
                        leftLaserBullet.left = false;
                        rightLaserBullet.damage = gunController.damage;
                        rightLaserBullet.range = gunController.range;

                        break;
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        // TODO- play hurt animation
        // TODO- play hurt sound effect

        hpBar.value -= damage;
        currentHP -= damage;

        if (currentHP <= 0)
            Die();
    }

    void Die()
    {
        // TODO- play death animation
        // TODO- play death sound effect
        FindObjectOfType<GameManager>().EndGame();
        Destroy(gameObject);
    }
}
