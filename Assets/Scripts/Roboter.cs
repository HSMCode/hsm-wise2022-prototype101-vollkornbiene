using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roboter : MonoBehaviour
{
    public float stepForward = 0.1f;
    public float stepRight = 0.1f;
    public float stepLeft = -0.1f;
    public float stepBack = -0.1f;
    public float stepUp = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(stepRight,0,stepBack);

        if(Input.GetKeyDown("w"))
        {
            //move roboter forward
            transform.Translate(0, 0, stepForward);
        }

        if (Input.GetKeyDown("d"))
        {
            //move roboter right
            transform.Translate(stepRight, 0, 0);
        }

        if (Input.GetKeyDown("a"))
        {
            //move roboter left
            transform.Translate(stepLeft, 0, 0);
        }

        if (Input.GetKeyDown("s"))
        {
            //move roboter back
            transform.Translate(0, 0, stepBack);
        }

        if (Input.GetKeyDown("space"))
        {
            //move roboter up
            transform.Translate(0, stepUp, 0);
        }

    }
}
