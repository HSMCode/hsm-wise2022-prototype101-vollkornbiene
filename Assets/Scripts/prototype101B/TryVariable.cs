using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryVariable : MonoBehaviour
{
    public int A = 4;
    public int B = 7;
    public int C = 1;
    public int D = 9;
    public int result1;
    public int result2;
    public string myString = "Das Ergebnis meiner Rechnung lautet ";

    // Start is called before the first frame update
    void Start()
    {
        result1 = A + B + C + D;
        result2 = result1 / 3;

        print(myString + result2);
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
