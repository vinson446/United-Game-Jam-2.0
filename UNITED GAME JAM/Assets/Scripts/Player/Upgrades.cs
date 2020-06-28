using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    ScoreCounter scoreCounter;
    GunController gunController;

    public int[] scoreThresholds;
    public int weaponUpgrades = 1;

    public int damageUpgrade;
    public float atkSpeedUpgrade;
    public int ammoUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = GetComponent<ScoreCounter>();
        gunController = FindObjectOfType<GunController>();
    }

    // Update is called once per frame
    void Update()
    {
        // laser rifle atk speed
        if (scoreCounter.scoreAmount >= scoreThresholds[21])
        {
            gunController.laserFireRate += atkSpeedUpgrade;
            gunController.fireRate = gunController.laserFireRate;
        }
        // laser rifle damage
        else if (scoreCounter.scoreAmount >= scoreThresholds[20])
        {
            gunController.laserDamage += damageUpgrade;
            gunController.damage = gunController.laserDamage;
        }
        // laser rifle ammo
        else if (scoreCounter.scoreAmount >= scoreThresholds[19])
        {
            gunController.laserMaxAmmo += ammoUpgrade;
        }
        // laser rifle unlock
        else if (scoreCounter.scoreAmount >= scoreThresholds[18])
        {
            weaponUpgrades = 6;
        }

        // minigun atk speed
        else if (scoreCounter.scoreAmount >= scoreThresholds[17])
        {
            gunController.minigunFireRate += atkSpeedUpgrade;
            gunController.fireRate = gunController.minigunFireRate;
        }
        // minigun damage
        else if (scoreCounter.scoreAmount >= scoreThresholds[16])
        {
            gunController.minigunDamage += damageUpgrade;
            gunController.damage = gunController.minigunDamage;
        }
        // minigun ammo
        else if (scoreCounter.scoreAmount >= scoreThresholds[15])
        {
            gunController.minigunMaxAmmo += ammoUpgrade;
        }
        // minigun unlock
        else if (scoreCounter.scoreAmount >= scoreThresholds[14])
        {
            weaponUpgrades = 5;
        }

        // grenade atk speed
        else if (scoreCounter.scoreAmount >= scoreThresholds[13])
        {
            gunController.grenadeFireRate += atkSpeedUpgrade;
            gunController.fireRate = gunController.grenadeFireRate;
        }
        // grenade damage
        else if (scoreCounter.scoreAmount >= scoreThresholds[12])
        {
            gunController.grenadeDamage += damageUpgrade;
            gunController.damage = gunController.grenadeDamage;
        }
        // grenade ammo
        else if (scoreCounter.scoreAmount >= scoreThresholds[11])
        {
            gunController.grenadeMaxAmmo += ammoUpgrade;
        }
        // grenade unlock
        else if (scoreCounter.scoreAmount >= scoreThresholds[10])
        {
            weaponUpgrades = 4;
        }

        // rifle atk speed
        else if (scoreCounter.scoreAmount >= scoreThresholds[9])
        {
            gunController.rifleFireRate += atkSpeedUpgrade;
            gunController.fireRate = gunController.rifleFireRate;
        }
        // rifle damage
        else if (scoreCounter.scoreAmount >= scoreThresholds[8])
        {
            gunController.rifleDamage += damageUpgrade;
            gunController.damage = gunController.rifleDamage;
        }
        // rifle ammo
        else if (scoreCounter.scoreAmount >= scoreThresholds[7])
        {
            gunController.rifleMaxAmmo += ammoUpgrade;
        }
        // rifle ammo
        else if (scoreCounter.scoreAmount >= scoreThresholds[6])
        {
            weaponUpgrades = 3;
        }

        // shotgun atk speed
        else if (scoreCounter.scoreAmount >= scoreThresholds[5])
        {
            gunController.shotgunFireRate += atkSpeedUpgrade;
            gunController.fireRate = gunController.shotgunFireRate;
        }
        // shotgun damage
        else if (scoreCounter.scoreAmount >= scoreThresholds[4])
        {
            gunController.shotgunDamage += damageUpgrade;
            gunController.damage = gunController.shotgunDamage;
        }
        // shotgun ammo
        else if (scoreCounter.scoreAmount >= scoreThresholds[3])
        {
            gunController.shotgunMaxAmmo += ammoUpgrade;
        }
        // shotgun unlock
        else if (scoreCounter.scoreAmount >= scoreThresholds[2])
        {
            weaponUpgrades = 2;
        }

        // pistol atk speed
        else if (scoreCounter.scoreAmount >= scoreThresholds[1])
        {
            gunController.pistolFireRate += atkSpeedUpgrade;
            gunController.fireRate = gunController.pistolFireRate;
        }
        // pistol damage
        else if (scoreCounter.scoreAmount >= scoreThresholds[0])
        {
            gunController.pistolDamage += damageUpgrade;
            gunController.damage = gunController.pistolDamage;
        }
    }
}
