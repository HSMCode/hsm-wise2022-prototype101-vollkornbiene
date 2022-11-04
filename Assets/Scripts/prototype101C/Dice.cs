using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int randomNumber;
    public float step = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown("space"))
        {
            transform.Translate(0, step, 0);
        }

       if(Input.GetKeyUp("space"))
        {
            transform.Translate(0, -step, 0);
            randomNumber = Random.Range(1, 7);
            print("Du hast eine " + randomNumber + " gewürfelt");
        }
    }
}
