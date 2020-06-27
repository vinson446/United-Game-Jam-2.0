using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiplierBar : MonoBehaviour
{
    public Image bar;
    public RectTransform knob;
    public TextMeshProUGUI multiplierAmmount;
    ScoreCounter scoreCounter;
    float multiplierText;
    float timeAmmount;

    private void Start()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    private void Update()
    {
        ChangeTimmer(scoreCounter.currentMultiplerTimer);
       // Debug.Log(FindObjectOfType<ScoreCounter>().currentMultiplerTimer);
    }

    public void ChangeTimmer(float time)
    {
        if (time <= 0)
            time = 0;
        //Debug.Log("changed timmer");
        float ammount = (time / scoreCounter.multiplierTimer) * 270f / 360;
        bar.fillAmount = ammount;
        float knobPosition = ammount * 360;
       
        knob.localEulerAngles = new Vector3(0, 0, knobPosition);
    }
    public void ChangeMultiplier(float currentMultiplier)
    {
        multiplierAmmount.text = "X" +currentMultiplier.ToString();
    }

}
