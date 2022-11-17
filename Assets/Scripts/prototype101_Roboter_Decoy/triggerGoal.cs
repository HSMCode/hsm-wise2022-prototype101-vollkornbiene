using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerGoal : MonoBehaviour
{
    public GameObject Roboter;
    public GameObject Decoy;

    private AudioSource _AudioSource;
    public AudioClip GoalSound;

    public ParticleSystem Confetti;

    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();

        Confetti = GetComponent<ParticleSystem>();
        Confetti.Pause();

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " just hit " + other.name);

        if (other.name == Roboter.name)
        {
            //when roboter collides with goal
            Debug.Log("Victory!");
            _AudioSource.PlayOneShot(GoalSound);
            //Destroy(gameObject, 1f);
            Confetti.Play();
        }
    }
}
