using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDecoy : MonoBehaviour
{
    public GameObject Roboter;
    public GameObject Decoy;

    public AudioSource _AudioSource;
    public AudioClip OuchSound;

    public int Hits = 1;

    private UpdateScore updateScore;

    void Start()
    {
        Roboter = GameObject.Find("robot");

        Roboter.SetActive(true);

        _AudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();

        updateScore = GameObject.Find("UpdateScore").GetComponent<UpdateScore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(gameObject.name + " just hit " + other.name);

        if (other.name == Roboter.name)
        {
            //when roboter collides with decoy
            _AudioSource.PlayOneShot(OuchSound);

            updateScore.UpdateHits(Hits);

        }
    }
}
