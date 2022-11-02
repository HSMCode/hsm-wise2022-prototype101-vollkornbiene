using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int randomNumber;
    public float stepJump = 1f;
    public float stepDown = -1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown("space"))
        {
            transform.Translate(0, stepJump, 0);
        }

       if(Input.GetKeyUp("space"))
        {
            transform.Translate(0, stepDown, 0);
            randomNumber = Random.Range(1, 7);
            print(randomNumber);
        }
    }
}
