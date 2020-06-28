using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool isSpawningEnemies;

    public int currentLevel = 1;

    public int currentNumberOfEnemies = 5;
    public int numberOfEnemiesLeftToSpawn = 5;
    public int maxNumberOfEnemies = 5;

    public int increaseInEnemiesPerLevel;
    public float spawnIntervals;

    public GameObject[] enemyObjsToSpawn;
    public Transform[] enemySpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        currentNumberOfEnemies = maxNumberOfEnemies;
        numberOfEnemiesLeftToSpawn = maxNumberOfEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfEnemiesLeftToSpawn > 0 && !isSpawningEnemies)
        {
            StartCoroutine(SpawnEnemies());
        }

        if (currentNumberOfEnemies <= 0)
        {
            LoadNextLevel();
        }
    }

    // enemy calls function when its created
    public void EnemySpawned()
    {
        numberOfEnemiesLeftToSpawn -= 1;
    }

    // enemy calls function when it dies
    public void EnemyDied()
    {
        currentNumberOfEnemies -= 1;
    }

    public void LoadNextLevel()
    {
        currentLevel += 1;

        maxNumberOfEnemies += increaseInEnemiesPerLevel;
        currentNumberOfEnemies = maxNumberOfEnemies;
        numberOfEnemiesLeftToSpawn = maxNumberOfEnemies;
    }

    IEnumerator SpawnEnemies()
    {
        isSpawningEnemies = true;

        for (int i = 0; i < Random.Range(0, numberOfEnemiesLeftToSpawn + 1); i++)
        {
            Instantiate(enemyObjsToSpawn[0], enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position, Quaternion.identity);
        }

        yield return new WaitForSeconds(spawnIntervals);

        isSpawningEnemies = false;
    }
}
