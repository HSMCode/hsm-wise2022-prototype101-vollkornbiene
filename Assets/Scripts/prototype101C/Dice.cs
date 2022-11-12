using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int randomNumber;
    public float step = 1f;
    public float luckyNumberOne = 1;
    public float luckyNumberTwo = 3;
    public float luckyNumberThree = 6;

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

        if (Input.GetKeyUp("space"))
        {
            transform.Translate(0, -step, 0);
            randomNumber = Random.Range(1, 7);
            print("Du hast eine " + randomNumber + " gew�rfelt");


            if (randomNumber == luckyNumberOne)
            {
                print("Herzlichen Gl�ckwunsch! " + luckyNumberOne + " ist eine Gewinnzahl!");
            }

            if (randomNumber == luckyNumberTwo)
            {
                print("Herzlichen Gl�ckwunsch! " + luckyNumberTwo + " ist eine Gewinnzahl!");
            }

            if (randomNumber == luckyNumberThree)
            {
                print("Herzlichen Gl�ckwunsch! " + luckyNumberThree + " ist eine Gewinnzahl!");
            }
        }
    }
}
