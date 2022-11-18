using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerGoal : MonoBehaviour
{
    public GameObject Roboter;
    public GameObject Decoy;

    private AudioSource _AudioSource;
    public AudioClip GoalSound;

    private ParticleSystem playParticlesSystem;
    private ParticleSystem emitParticlesSystem;

    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(gameObject.name + " just hit " + other.name);

        if (other.name == Roboter.name)
        {
            // when roboter collides with goal
            Debug.Log("Victory!");

            _AudioSource.PlayOneShot(GoalSound);

            // EmitParticles();
            PlayParticles(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.name == Roboter.name)
        {
            PlayParticles(false);

            Destroy(gameObject);
        }
    }

    void EmitParticles()
    {
        emitParticlesSystem.Emit(5);
    }

    void PlayParticles(bool on)
    {
        if (on)
        {
            playParticlesSystem.Play();
        }
         if (!on)
        {
            playParticlesSystem.Stop();
        }
    }

}
