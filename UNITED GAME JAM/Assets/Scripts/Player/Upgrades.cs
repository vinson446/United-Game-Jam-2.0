using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    ScoreCounter scoreCounter;
    GunController gunController;

    public int[] scoreThresholds;
    public int weaponUpgrades = 1;

    [Header("Pistol Upgrades")]
    public int pistolDamageUpgrade;
    public float pistolAtkSpeedUpgrade;

    [Header("Shotgun Upgrades")]
    public int shotgunDamageUpgrade;
    public float shotgunAtkSpeedUpgrade;
    public int shotgunMaxAmmoUpgrade;

    [Header("Assault Rifle Upgrades")]
    public int rifleDamageUpgrade;
    public float rifleAtkSpeedUpgrade;
    public int rifleMaxAmmoUpgrade;

    [Header("Grenade Launcher Upgrades")]
    public int grenadeDamageUpgrade;
    public float grenadeAtkSpeedUpgrade;
    public int grenadeMaxAmmoUpgrade;

    [Header("Minigun")]
    public int minigunDamageUpgrade;
    public float minigunAtkSpeedUpgrade;
    public int minigunMaxAmmoUpgrade;

    [Header("Laser Rifle")]
    public int laserDamageUpgrade;
    public float laserAtkSpeedUpgrade;
    public int laserMaxAmmoUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
        gunController = FindObjectOfType<GunController>();
    }

    // Update is called once per frame
    void Update()
    {
        // laser rifle atk speed
        if (scoreCounter.scoreAmount >= scoreThresholds[21])
        {
            gunController.laserFireRate = laserAtkSpeedUpgrade;
            gunController.fireRate = gunController.laserFireRate;
        }
        // laser rifle damage
        else if (scoreCounter.scoreAmount >= scoreThresholds[20])
        {
            gunController.laserDamage = laserDamageUpgrade;
            gunController.damage = gunController.laserDamage;
        }
        // laser rifle ammo
        else if (scoreCounter.scoreAmount >= scoreThresholds[19])
        {
            gunController.laserMaxAmmo = laserMaxAmmoUpgrade;
        }
        // laser rifle unlock
        else if (scoreCounter.scoreAmount >= scoreThresholds[18])
        {
            weaponUpgrades = 6;
        }

        // minigun atk speed
        else if (scoreCounter.scoreAmount >= scoreThresholds[17])
        {
            gunController.minigunFireRate = minigunAtkSpeedUpgrade;
            gunController.fireRate = gunController.minigunFireRate;
        }
        // minigun damage
        else if (scoreCounter.scoreAmount >= scoreThresholds[16])
        {
            gunController.minigunDamage = minigunDamageUpgrade;
            gunController.damage = gunController.minigunDamage;
        }
        // minigun ammo
        else if (scoreCounter.scoreAmount >= scoreThresholds[15])
        {
            gunController.minigunMaxAmmo = minigunMaxAmmoUpgrade;
        }
        // minigun unlock
        else if (scoreCounter.scoreAmount >= scoreThresholds[14])
        {
            weaponUpgrades = 5;
        }

        // grenade atk speed
        else if (scoreCounter.scoreAmount >= scoreThresholds[13])
        {
            gunController.grenadeFireRate = grenadeAtkSpeedUpgrade;
            gunController.fireRate = gunController.grenadeFireRate;
        }
        // grenade damage
        else if (scoreCounter.scoreAmount >= scoreThresholds[12])
        {
            gunController.grenadeDamage = grenadeDamageUpgrade;
            gunController.damage = gunController.grenadeDamage;
        }
        // grenade ammo
        else if (scoreCounter.scoreAmount >= scoreThresholds[11])
        {
            gunController.grenadeMaxAmmo = grenadeMaxAmmoUpgrade;
        }
        // grenade unlock
        else if (scoreCounter.scoreAmount >= scoreThresholds[10])
        {
            weaponUpgrades = 4;
        }

        // rifle atk speed
        else if (scoreCounter.scoreAmount >= scoreThresholds[9])
        {
            gunController.rifleFireRate = rifleAtkSpeedUpgrade;
            gunController.fireRate = gunController.rifleFireRate;
        }
        // rifle damage
        else if (scoreCounter.scoreAmount >= scoreThresholds[8])
        {
            gunController.rifleDamage = rifleDamageUpgrade;
            gunController.damage = gunController.rifleDamage;
        }
        // rifle ammo
        else if (scoreCounter.scoreAmount >= scoreThresholds[7])
        {
            gunController.rifleMaxAmmo = rifleMaxAmmoUpgrade;
        }
        // rifle ammo
        else if (scoreCounter.scoreAmount >= scoreThresholds[6])
        {
            weaponUpgrades = 3;
        }

        // shotgun atk speed
        else if (scoreCounter.scoreAmount >= scoreThresholds[5])
        {
            gunController.shotgunFireRate = shotgunAtkSpeedUpgrade;
            gunController.fireRate = gunController.shotgunFireRate;
        }
        // shotgun damage
        else if (scoreCounter.scoreAmount >= scoreThresholds[4])
        {
            gunController.shotgunDamage = shotgunDamageUpgrade;
            gunController.damage = gunController.shotgunDamage;
        }
        // shotgun ammo
        else if (scoreCounter.scoreAmount >= scoreThresholds[3])
        {
            gunController.shotgunMaxAmmo = shotgunDamageUpgrade;
        }
        // shotgun unlock
        else if (scoreCounter.scoreAmount >= scoreThresholds[2])
        {
            weaponUpgrades = 2;
        }

        // pistol atk speed
        else if (scoreCounter.scoreAmount >= scoreThresholds[1])
        {
            gunController.pistolFireRate = pistolAtkSpeedUpgrade;
            gunController.fireRate = gunController.pistolFireRate;
        }
        // pistol damage
        else if (scoreCounter.scoreAmount >= scoreThresholds[0])
        {
            gunController.pistolDamage = pistolDamageUpgrade;
            gunController.damage = gunController.pistolDamage;
        }
    }
}
