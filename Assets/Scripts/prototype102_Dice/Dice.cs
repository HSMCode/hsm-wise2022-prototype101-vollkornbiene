using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int randomNumber;
    public float step = 1f;
    //public int luckyNumberA = 1;
    //public int luckyNumberB = 3;
    //public int luckyNumberC = 6;

    // array
    public int[] luckyNumbers = { 1, 5, 10, 15, 25, 35, 45, 50 };
    //public int[] luckyNumbers = new int[3];

    private AudioSource _AudioSource;
    public AudioClip VictorySound;

    // Start is called before the first frame update
    void Start()
    {
        //luckyNumbers[0] = 1;
        //luckyNumbers[1] = 3;
        //luckyNumbers[2] = 6;

        _AudioSource = GetComponent<AudioSource>();
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
           randomNumber = Random.Range(1, 51);
           print("Du hast eine " + randomNumber + " gewürfelt");


            for(int i = 0; i < luckyNumbers.Length; i++)
            {
                //print("for loop i " + i);

                if (randomNumber == luckyNumbers[i])
                {
                    print("Herzlichen Glückwunsch! " + randomNumber + " ist eine Gewinnzahl!");
                    _AudioSource.PlayOneShot(VictorySound);
                }

                else
                {
                    print("Niete.");
                }
            }


            //if (randomNumber == luckyNumberA || randomNumber == luckyNumberB || randomNumber == luckyNumberC)
            //{
            //    print("Herzlichen Glückwunsch! " + randomNumber + " ist eine Gewinnzahl!");
            //}


            //if (randomNumber == luckyNumbers[0] || randomNumber == luckyNumbers[1] || randomNumber == luckyNumbers[2])
            //{
            //    print("Herzlichen Glückwunsch! " + randomNumber + " ist eine Gewinnzahl!");
            //}


            //if(randomNumber == luckyNumberA)
            //{
            //    print("Herzlichen Glückwunsch! " + randomNumber + " ist eine Gewinnzahl!");
            //}

            //else if (randomNumber == luckyNumberB)
            //{
            //    print("Herzlichen Glückwunsch! " + randomNumber + " ist eine Gewinnzahl!");
            //}

            //else if (randomNumber == luckyNumberC)
            //{
            //    print("Herzlichen Glückwunsch! " + randomNumber + " ist eine Gewinnzahl!");
            //}


            //else
            //{
            //    print("Niete.");
            //}
        }
    }
}
