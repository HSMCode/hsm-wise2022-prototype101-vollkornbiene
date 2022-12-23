using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private bool _canStart;
    public int countdown;

    void Start()
    {
        _canStart = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && _canStart)
        {
            StartCoroutine(CountingDown());
        }

        else if (Input.GetKeyDown(KeyCode.C) && !_canStart)
        {
            Debug.Log("Wait for Coroutine to be ready again.");
        }
    }

    // coroutine countdown to test
    private IEnumerator CountingDown()
    {
        _canStart = false;

        Debug.Log("Waiting for seconds of Countdown: " + countdown);

        yield return new WaitForSeconds(countdown);

        Debug.Log("Coroutine ready to start again.");

        _canStart = true;
    }


    //private IEnumerator CountingDown()
    //{
    //    _canStart = false;

    //    Debug.Log("Waiting for seconds of Countdown: " + countdown);

    //    // yield return new WaitForSeconds(countdown);

    //    int i = countdown;
    //    for (; i > 0; i--)
    //    {
    //        Debug.Log("Ready in " + i + " Sec.");

    //        yield return new WaitForSeconds(1f);

    //        yield return null;
    //    }

    //    Debug.Log("Coroutine ready to start again.");

    //    _canStart = true;
    //}
}
