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

    private PanelControl panelControl;

    void Start()
    {
        Roboter = GameObject.Find("robot");

        Roboter.SetActive(true);

        _AudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();

        panelControl = GameObject.Find("UpdateScore").GetComponent<PanelControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(gameObject.name + " just hit " + other.name);

        if (other.name == Roboter.name)
        {
            //when roboter collides with decoy
            _AudioSource.PlayOneShot(OuchSound);

            panelControl.UpdateHits(Hits);

        }
    }
}
