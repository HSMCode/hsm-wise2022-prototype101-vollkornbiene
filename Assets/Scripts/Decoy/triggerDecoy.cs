using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDecoy : MonoBehaviour
{
    public GameObject Roboter;
    public AudioSource myAudioSource;
    public AudioClip OuchSound;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " just hit " + other.name);

        if (other.name == Roboter.name)
        {
            //when roboter collides with decoy
            Debug.Log("Ouch!");
            myAudioSource.Play();
        }
    }
}
