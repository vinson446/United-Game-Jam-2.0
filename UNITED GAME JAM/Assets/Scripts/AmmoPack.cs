using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    [Header("Animation")]
    public float rotationAmmount = 30f;
    public float rotationSpeed = 5f;
    public float bounceAmmount = 5f;
    [Header("Atribuites")]
    public int typeOfGunAmmo;
    public int ammoAmmount = 25;

    GunController gunController;
    Upgrades upgrades;

    // Start is called before the first frame update
    void Start()
    {
        gunController = FindObjectOfType<GunController>();
        upgrades = FindObjectOfType<Upgrades>();

        typeOfGunAmmo = Random.Range(2, upgrades.weaponUpgrades + 1);
    }


    void Update()
    {
        Spin();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (typeOfGunAmmo == 2)
            {
                gunController.shotgunCurrentAmmo += ammoAmmount;

                if (gunController.shotgunCurrentAmmo > gunController.shotgunMaxAmmo)
                    gunController.shotgunCurrentAmmo = gunController.shotgunMaxAmmo;

                gunController.currentAmmo = gunController.shotgunCurrentAmmo;
            }
            else if (typeOfGunAmmo == 3)
            {
                gunController.rifleCurrentAmmo += ammoAmmount;

                if (gunController.rifleCurrentAmmo > gunController.rifleMaxAmmo)
                    gunController.rifleCurrentAmmo = gunController.rifleMaxAmmo;

                gunController.currentAmmo = gunController.rifleCurrentAmmo;
            }
            else if (typeOfGunAmmo == 4)
            {
                gunController.grenadeCurrentAmmo += ammoAmmount;

                if (gunController.grenadeCurrentAmmo > gunController.grenadeMaxAmmo)
                    gunController.grenadeCurrentAmmo = gunController.grenadeMaxAmmo;

                gunController.currentAmmo = gunController.grenadeCurrentAmmo;
            }
            else if (typeOfGunAmmo == 5)
            {
                gunController.minigunCurrentAmmo += ammoAmmount;

                if (gunController.minigunCurrentAmmo > gunController.minigunMaxAmmo)
                    gunController.minigunCurrentAmmo = gunController.minigunMaxAmmo;

                gunController.currentAmmo = gunController.minigunCurrentAmmo;
            }
            else if (typeOfGunAmmo == 6)
            {
                gunController.laserCurrentAmmo += ammoAmmount;

                if (gunController.laserCurrentAmmo > gunController.laserMaxAmmo)
                    gunController.laserCurrentAmmo = gunController.laserMaxAmmo;

                gunController.currentAmmo = gunController.laserCurrentAmmo;
            }

            Destroy(gameObject);
        }
    }





    void Spin()
    {
        transform.Rotate(new Vector3(0, 0, rotationAmmount) * Time.deltaTime * rotationSpeed);
        transform.Translate(new Vector3(0, 0, Mathf.Sin(Time.time * bounceAmmount)) * Time.deltaTime);
    }
}
