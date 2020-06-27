using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [Header("Animation")]
    public float rotationAmmount = 30f;
    public float rotationSpeed = 5f;
    public float bounceAmmount = 5f;
    [Header("Atribuites")]
    public int HealthAmmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        Spin();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            PlayerController player = collider.GetComponent<PlayerController>();
            Debug.Log("Healed Player for " + HealthAmmount);
            player.currentHP += HealthAmmount;
        }
    }





    void Spin()
    {
        transform.Rotate(new Vector3(0, 0, rotationAmmount) * Time.deltaTime * rotationSpeed);
        transform.Translate(new Vector3(0, 0, Mathf.Sin(Time.time * bounceAmmount)) * Time.deltaTime);
    }
}