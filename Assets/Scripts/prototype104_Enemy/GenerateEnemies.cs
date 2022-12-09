using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject[] Enemy;

    public int spawnAmount;

    public float spawnPositionXa = 10f;
    public float spawnPositionXb = 10f;
    public float spawnPositionZa = 10f;
    public float spawnPositionZb = 10f;

    public float startDelay = 2f;
    public float spawnInterval = 3f;


    // Start is called before the first frame update
    void Start()
    {
        spawnAmount = Random.Range(5, 11);

        SpawningEnemyParam(spawnAmount);

        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void SpawningEnemyParam(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int enemyIndex = Random.Range(0, Enemy.Length);

            // generate random spawn position between the defined values
            Vector3 RandomEnemyPosition = new Vector3(Random.Range(-spawnPositionXa, spawnPositionXb), 0f, Random.Range(-spawnPositionZa, spawnPositionZb));

            // instantiate enemy
            Instantiate(Enemy[enemyIndex], RandomEnemyPosition, Quaternion.identity);
        }
    }

}
