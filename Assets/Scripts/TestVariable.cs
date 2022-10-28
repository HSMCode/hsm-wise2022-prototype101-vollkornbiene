using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVariable : MonoBehaviour
{
    public int numberOne = 1;
    public int numberTwo = 2;
    public int result;
    public float myFloat = 3f;
    public string myString = "Hier könnte ihre Werbung stehen: ";

    // Start is called before the first frame update
    void Start()
    {
        result = numberOne + numberTwo;

        Debug.Log("Das Resultat: " + result);
        Debug.Log(myString + myFloat);
        Debug.LogFormat("My more easy to read log, with my float {0}, my cool integer result variable {1} and a random sentence {2}.", myFloat,result,myString) ;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
