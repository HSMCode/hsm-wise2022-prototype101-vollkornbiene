using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    public GameObject[] Goals;
    private int goalsIndex;

    public GameObject Finish;

    // Start is called before the first frame update
    void Start()
    {
        Finish.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //CheckGoalsDestroyed();

        if(Goals == null)
        {
            Finish.SetActive(true);
        }
    }

    //private void CheckGoalsDestroyed()
    //{
    //    for (int i = 0; i < 11; ++i)
    //    {
    //        if (i == 0)
    //        {
    //            Finish.SetActive(true);
    //        }
    //    }
    //}
}
