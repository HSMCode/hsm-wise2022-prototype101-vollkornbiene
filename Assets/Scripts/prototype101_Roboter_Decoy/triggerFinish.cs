using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerFinish : MonoBehaviour
{
    public GameObject Roboter;

    public bool finish = false;

    private UpdateScore updateScore;

    // Start is called before the first frame update
    void Start()
    {
        updateScore = GameObject.Find("UpdateScore").GetComponent<UpdateScore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == Roboter.name)
        {
            updateScore.CheckGameOver(finish = true);
            print("finish");
        }
    }
}
