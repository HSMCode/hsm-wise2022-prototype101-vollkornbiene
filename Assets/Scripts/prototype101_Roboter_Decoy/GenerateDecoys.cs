using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDecoys : MonoBehaviour
{
    public GameObject[] Decoys;

    public int spawnAmount;

    public int spawnPositionXa = 9;
    public int spawnPositionXb = 10;
    public int spawnPositionZa = 2;
    public int spawnPositionZb = 11;

    public float startDelay = 2f;
    public float spawnInterval = 3f;


    // Start is called before the first frame update
    void Start()
    {
        // SpawningDecoy();
        // InvokeRepeating("SpawningDecoy", startDelay, spawnInterval);

        // randomize spawn amount
        spawnAmount = Random.Range(20, 41);

        SpawningDecoyParam(spawnAmount);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //void SpawningDecoy()
    //{
    //    for (int i = 0; i < spawnAmount; i++)
    //    {
    //        // generate random spawn position between the defined values
    //        Vector3 RandomDecoyPosition = new Vector3(Random.Range(-spawnPositionXa, spawnPositionXb), 0, Random.Range(spawnPositionZa, spawnPositionZb));

    //        // instantiate decoy
    //        Instantiate(Decoy, RandomDecoyPosition, Quaternion.identity);
    //    }
    //}

    void SpawningDecoyParam(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int decoysIndex = Random.Range(0, Decoys.Length);

            // generate random spawn position between the defined values
            Vector3 RandomDecoyPosition = new Vector3(Random.Range(-spawnPositionXa, spawnPositionXb), 0, Random.Range(spawnPositionZa, spawnPositionZb));

            // instantiate decoy
            Instantiate(Decoys[decoysIndex], RandomDecoyPosition, Quaternion.identity);
        }
    }
  
}
