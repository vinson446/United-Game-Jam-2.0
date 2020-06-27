using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float scoreAmount = 0;
    public float multiplierAmmount = 1;
    public float multiplierTimer = 10;
    public float currentMultiplerTimer;

    private void Start()
    {
        currentMultiplerTimer = multiplierTimer;
    }
    private void FixedUpdate()
    {
        currentMultiplerTimer -= Time.deltaTime;
      
    }

    void Update()
    {
        scoreText.text = scoreAmount.ToString();

    }

    public void Addpoints(float pointAmmount)
    {
        //Check if mulitiplier has been reset
        if (currentMultiplerTimer <= 0)
        {
            //set multiplier back
            multiplierAmmount = 1;
        }
        else
        {
            //add multiplier
            multiplierAmmount++;
        }

        //reset multiplier
        currentMultiplerTimer = multiplierTimer;

        //add points
        scoreAmount += pointAmmount * multiplierAmmount;

        //refrerance and change multiplier
        FindObjectOfType<MultiplierBar>().ChangeMultiplier(multiplierAmmount);
    }


}
