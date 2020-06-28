using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFire : MonoBehaviour
{
    public GameObject lazer;
    public GameObject firePoint;


    private GameObject spawnedLazer;
    // Start is called before the first frame update
    void Start()
    {
        spawnedLazer = Instantiate(lazer, firePoint.transform) as GameObject;
        DisableLaser();
    }

    // Update is called once per frame
    void Update()
    {
        //click
        //enablelaser

       // hold click
       //upadtelazer

        //button up
        //disable 
    }

    void EnableLaser()
    {
        spawnedLazer.SetActive(true);
    }
     void UpdateLaser()
    {
        if (firePoint != null)
            spawnedLazer.transform.position=firePoint.transform.position;
    }    

    void DisableLaser()
    {
        spawnedLazer.SetActive(false);
    }
        
}





