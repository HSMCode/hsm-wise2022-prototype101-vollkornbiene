using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryDebug : MonoBehaviour
{
    public float stepJump = 1f;
    public float stepDown = -1f;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Game gestartet");
        Debug.Log("Steuerung: Leertaste und WASD");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            transform.Translate(0, stepJump, 0);
            Debug.Log("Würfel oben");
        }

        if(Input.GetKeyUp("space"))
        {
            transform.Translate(0, stepDown, 0);
            Debug.LogWarning("Würfel gelandet");
        }

        if(Input.GetKeyDown("w"))
        {
            Debug.LogError("der Würfel kann nicht laufen");
        }
    }
}
