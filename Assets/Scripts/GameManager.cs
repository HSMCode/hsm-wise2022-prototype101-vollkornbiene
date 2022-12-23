using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Load Prototype_104_Enemy Scene
        SceneManager.LoadScene(4);
    }


    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.L))
    //    {
    //        //SceneManager.LoadScene("Start");
    //        SceneManager.LoadScene(2);
    //    }

    //    if (Input.GetKey(KeyCode.R))
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    }
    //}
}
