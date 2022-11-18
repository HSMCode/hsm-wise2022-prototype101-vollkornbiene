using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDecoy : MonoBehaviour
{
    public GameObject Roboter;
    public GameObject Decoy;
    private AudioSource _AudioSource;
    public AudioClip OuchSound;
    

    void Start()
    {
        Roboter = GameObject.Find("robot");

        Roboter.SetActive(true);

        _AudioSource = GetComponent<AudioSource>();

        //Vector3 RandomDecoyPosition = new Vector3(Random.Range(-10, 11),0,Random.Range(-10,11));
        //Instantiate(Decoy, RandomDecoyPosition, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " just hit " + other.name);

        if (other.name == Roboter.name)
        {
            //when roboter collides with decoy
            Debug.Log("Ouch!");
            _AudioSource.PlayOneShot(OuchSound);
            Roboter.SetActive(false);
        }
    }
}
