using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public int typeOfGun = 1;

    public int damage;
    public float fireRate;
    public float maxAmmo;
    public float currentAmmo;
    public float range;

    public GameObject LeftGunHolder;
    public GameObject RightGunHolder;
    public Vector3 weaponOffset;
    public GameObject[] bullets;
    public Transform leftBulletSpawn;
    public Transform rightBulletSpawn;

    [Header("Pistol")]
    public GameObject pistol;
    public Vector3 pistolOffset;

    public int pistolDamage;
    public float pistolFireRate;
    public float pistolRange;

    [Header("Shotgun")]
    public GameObject shotgun;
    public Vector3 shotgunOffset;

    public int shotgunDamage;
    public float shotgunFireRate;
    public float shotgunRange;

    public float shotgunCurrentAmmo;
    public float shotgunMaxAmmo;

    [Header("Assault Rifle")]
    public GameObject rifle;
    public Vector3 rifleOffset;

    public int rifleDamage;
    public float rifleFireRate;
    public float rifleRange;

    public float rifleCurrentAmmo;
    public float rifleMaxAmmo;

    [Header("GrenadeLauncher")]
    public GameObject grenade;
    public Vector3 grenadeOffset;

    public int grenadeDamage;
    public float grenadeFireRate;
    public float grenadeRange;

    public float grenadeCurrentAmmo;
    public float grenadeMaxAmmo;

    public float grenadeAOERange;

    [Header("Minigun")]
    public GameObject minigun;
    public Vector3 minigunOffset;

    public int minigunDamage;
    public float minigunFireRate;
    public float minigunRange;

    public float minigunCurrentAmmo;
    public float minigunMaxAmmo;

    [Header("Laser Rifle")]
    public GameObject laser;
    public Vector3 laserOffset;

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
        switch(gun)
        {
            // pistol
            case 1:
                typeOfGun = 1;
                weaponOffset = pistolOffset;

                damage = pistolDamage;
                fireRate = pistolFireRate;
                range = pistolRange;
                break;
            // shotgun
            case 2:
                typeOfGun = 2;
                weaponOffset = shotgunOffset;

                damage = shotgunDamage;
                fireRate = shotgunFireRate;
                range = shotgunRange;

                maxAmmo = shotgunMaxAmmo;
                currentAmmo = shotgunCurrentAmmo;
                break;
            // assault rifle
            case 3:
                typeOfGun = 3;
                weaponOffset = rifleOffset;

                damage = rifleDamage;
                fireRate = rifleFireRate;
                range = rifleRange;

                maxAmmo = rifleMaxAmmo;
                currentAmmo = rifleCurrentAmmo;
                break;
            // grenade launcher
            case 4:
                typeOfGun = 4;
                weaponOffset = grenadeOffset;

                damage = grenadeDamage;
                fireRate = grenadeFireRate;
                range = grenadeRange;

                maxAmmo = grenadeMaxAmmo;
                currentAmmo = grenadeCurrentAmmo;
                break;
            // minigun
            case 5:
                typeOfGun = 5;
                weaponOffset = minigunOffset;

                damage = minigunDamage;
                fireRate = minigunFireRate;
                range = minigunRange;

                maxAmmo = minigunMaxAmmo;
                currentAmmo = minigunCurrentAmmo;
                break;
            // laser rifle
            case 6:
                typeOfGun = 6;
                weaponOffset = laserOffset;

                damage = laserDamage;
                fireRate = laserFireRate;
                range = laserRange;

                maxAmmo = minigunMaxAmmo;
                currentAmmo = minigunCurrentAmmo;
                break;
        }
    }
}
