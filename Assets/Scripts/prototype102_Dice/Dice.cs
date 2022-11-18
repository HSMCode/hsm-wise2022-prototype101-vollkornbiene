using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public float step = 1f;

    public int randomNumber;

    // initialize array
    public int[] luckyNumbers = { 1, 5, 10, 15, 25, 35, 45, 50 };
    //public int[] luckyNumbers = new int[3];

    // initialize audio
    private AudioSource _AudioSource;
    public AudioClip VictorySound;

    //initialize win bool
    public bool LuckyNumberWasDrawn;


    // Start is called before the first frame update
    void Start()
    {
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
           print("Du hast eine " + randomNumber + " gew�rfelt");

            LuckyNumberWasDrawn = false;


            for(int i = 0; i < luckyNumbers.Length; i++)
            {
                //print("for loop i " + i);

                if (randomNumber == luckyNumbers[i])
                {
                    print("Herzlichen Gl�ckwunsch! " + randomNumber + " ist eine Gewinnzahl!");
                    LuckyNumberWasDrawn = true;
                    _AudioSource.PlayOneShot(VictorySound);
                }

                else if (i == (luckyNumbers.Length-1) && LuckyNumberWasDrawn == false)
                {
                    print("Niete.");
                }
            }

        }
    }
}
