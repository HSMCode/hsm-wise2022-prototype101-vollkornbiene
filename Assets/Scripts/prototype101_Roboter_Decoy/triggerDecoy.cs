using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDecoy : MonoBehaviour
{
    public GameObject Roboter;
    public GameObject Decoy;

    public AudioSource _AudioSource;
    public AudioClip OuchSound;
    

    void Start()
    {
        Roboter = GameObject.Find("robot");

        Roboter.SetActive(true);

        _AudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(gameObject.name + " just hit " + other.name);

        if (other.name == Roboter.name)
        {
            //when roboter collides with decoy
            Debug.Log("Ouch!");

            _AudioSource.PlayOneShot(OuchSound);

            //Roboter.SetActive(false);

        }
    }
}
