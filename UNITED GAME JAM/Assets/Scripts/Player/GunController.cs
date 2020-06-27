using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public int typeOfGun = 1;
    public GameObject[] leftGuns;
    public GameObject[] rightGuns;

    public int damage;
    public float fireRate;
    public float maxAmmo;
    public float currentAmmo;
    public float range;

    public GameObject[] bullets;
    public Transform leftBulletSpawn;
    public Transform rightBulletSpawn;

    [Header("Pistol")]
    public int pistolDamage;
    public float pistolFireRate;
    public float pistolRange;

    [Header("Shotgun")]
    public int shotgunDamage;
    public float shotgunFireRate;
    public float shotgunRange;

    public float shotgunCurrentAmmo;
    public float shotgunMaxAmmo;

    [Header("Assault Rifle")]
    public int rifleDamage;
    public float rifleFireRate;
    public float rifleRange;

    public float rifleCurrentAmmo;
    public float rifleMaxAmmo;

    [Header("GrenadeLauncher")]
    public int grenadeDamage;
    public float grenadeFireRate;
    public float grenadeRange;

    public float grenadeCurrentAmmo;
    public float grenadeMaxAmmo;

    public float grenadeAOERange;

    [Header("Minigun")]
    public int minigunDamage;
    public float minigunFireRate;
    public float minigunRange;

    public float minigunCurrentAmmo;
    public float minigunMaxAmmo;

    [Header("Laser Rifle")]
    public int laserDamage;
    public float laserFireRate;
    public float laserRange;

    public float laserCurrentAmmo;
    public float laserMaxAmmo;

    // Start is called before the first frame update
    void Start()
    {
        SwitchGun(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchGun(int gun)
    {
        switch (gun)
        {
            // pistol
            case 1:
                typeOfGun = 1;

                damage = pistolDamage;
                fireRate = pistolFireRate;
                range = pistolRange;
                break;
            // shotgun
            case 2:
                typeOfGun = 2;

                damage = shotgunDamage;
                fireRate = shotgunFireRate;
                range = shotgunRange;

                maxAmmo = shotgunMaxAmmo;
                currentAmmo = shotgunCurrentAmmo;
                break;
            // assault rifle
            case 3:
                typeOfGun = 3;

                damage = rifleDamage;
                fireRate = rifleFireRate;
                range = rifleRange;

                maxAmmo = rifleMaxAmmo;
                currentAmmo = rifleCurrentAmmo;
                break;
            // grenade launcher
            case 4:
                typeOfGun = 4;

                damage = grenadeDamage;
                fireRate = grenadeFireRate;
                range = grenadeRange;

                maxAmmo = grenadeMaxAmmo;
                currentAmmo = grenadeCurrentAmmo;
                break;
            // minigun
            case 5:
                typeOfGun = 5;

                damage = minigunDamage;
                fireRate = minigunFireRate;
                range = minigunRange;

                maxAmmo = minigunMaxAmmo;
                currentAmmo = minigunCurrentAmmo;
                break;
            // laser rifle
            case 6:
                typeOfGun = 6;

                damage = laserDamage;
                fireRate = laserFireRate;
                range = laserRange;

                maxAmmo = minigunMaxAmmo;
                currentAmmo = minigunCurrentAmmo;
                break;
        }

        for (int i = 0; i < 6; i++)
        {
            leftGuns[i].SetActive(false);
            rightGuns[i].SetActive(false);
        }
        leftGuns[typeOfGun - 1].SetActive(true);
        rightGuns[typeOfGun - 1].SetActive(true);
    }
}
