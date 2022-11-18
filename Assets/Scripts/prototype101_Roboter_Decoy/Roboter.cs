using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roboter : MonoBehaviour
{
    public float step = 1f;
    public float turn = 90f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w"))
        {
            //move roboter forward
            transform.Translate(0, 0, step, Space.World);
        }

        if (Input.GetKeyDown("d"))
        {
            //move roboter right
            transform.Translate(step, 0, 0, Space.World);
        }

        if (Input.GetKeyDown("a"))
        {
            //move roboter left
            transform.Translate(-step, 0, 0, Space.World);
        }

        if (Input.GetKeyDown("s"))
        {
            //move roboter back
            transform.Translate(0, 0, -step, Space.World);
        }

        if (Input.GetKeyDown("space"))
        {
            //move roboter up
            transform.Translate(0, step, 0);
        }

        if (Input.GetKeyUp("space"))
        {
            //move roboter down
            transform.Translate(0, -step,0);
        }

        if (Input.GetKeyDown("q"))
        {
            //rotate roboter y-axis left
            transform.Rotate(0, -turn, 0);
        }

        if (Input.GetKeyDown("e"))
        {
            //rotate roboter y-axis right
            transform.Rotate(0, turn, 0);
        }

    }
}
