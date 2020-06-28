using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    bool gameStatus = false;
    public float restartDelay = 1f;
    public GameObject deathMenu;

    public void Start()
    {
        deathMenu.SetActive(false);
    }
    public void EndGame()
    {
        if (gameStatus == false)
        {
            gameStatus = true;
            deathMenu.SetActive(true);
        }
       
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
