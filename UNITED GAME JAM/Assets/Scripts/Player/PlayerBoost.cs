using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
    public float cooldown;
    public float boostAmount;
    public float boostDuration;
    float timer;

    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= timer)
        {
            timer = Time.time + cooldown;

            StartCoroutine(MovespeedBoost());
        }
    }

    IEnumerator MovespeedBoost()
    {
        player.moveSpeed *= boostAmount;

        yield return new WaitForSeconds(boostDuration);

        player.moveSpeed /= boostAmount;
    }
}
