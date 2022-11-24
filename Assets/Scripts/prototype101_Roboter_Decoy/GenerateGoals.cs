using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGoals : MonoBehaviour
{
    public GameObject Goal;

    public int spawnAmount;

    public float spawnPositionXa = 9f;
    public float spawnPositionXb = 10f;
    public float spawnPositionZa = 2f;
    public float spawnPositionZb = 11f;

    public float startDelay = 2f;
    public float spawnInterval = 3f;


    // Start is called before the first frame update
    void Start()
    {
        // randomize spawn amount
        spawnAmount = Random.Range(1, 11);

        SpawningGoalParam(spawnAmount);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawningGoalParam(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            // generate random spawn position between the defined values
            Vector3 RandomGoalPosition = new Vector3(Random.Range(-spawnPositionXa, spawnPositionXb), 0, Random.Range(spawnPositionZa, spawnPositionZb));

            // instantiate decoy
            Instantiate(Goal, RandomGoalPosition, Quaternion.identity);
        }
    }

}

