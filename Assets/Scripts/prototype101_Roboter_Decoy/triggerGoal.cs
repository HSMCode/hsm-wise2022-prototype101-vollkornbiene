using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerGoal : MonoBehaviour
{
    public GameObject Roboter;

    public AudioSource _AudioSource;
    public AudioClip GoalSound;

    public ParticleSystem playParticlesSystem;
    public ParticleSystem emitParticlesSystem;

    public int Items = 1;

    private UpdateScore updateScore;

    void Start()
    {
        _AudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();

        playParticlesSystem = GameObject.Find("ParticlesSystemPlay").GetComponent<ParticleSystem>();
        emitParticlesSystem = GameObject.Find("ParticlesSystemEmit").GetComponent<ParticleSystem>();

        updateScore = GameObject.Find("UpdateScore").GetComponent<UpdateScore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(gameObject.name + " just hit " + other.name);

        if (other.name == Roboter.name)
        {
            // when roboter collides with goal
            _AudioSource.PlayOneShot(GoalSound);

            updateScore.UpdateItems(Items);
            
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

    //void EmitParticles()
    //{
    //    emitParticlesSystem.Emit(5);
    //}

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
