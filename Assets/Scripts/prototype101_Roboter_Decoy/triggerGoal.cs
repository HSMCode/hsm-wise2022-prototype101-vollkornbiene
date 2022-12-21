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

    private PanelControl panelControl;

    void Start()
    {
        _AudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();

        playParticlesSystem = GameObject.Find("ParticlesSystemPlay").GetComponent<ParticleSystem>();
        emitParticlesSystem = GameObject.Find("ParticlesSystemEmit").GetComponent<ParticleSystem>();

        panelControl = GameObject.Find("UpdateScore").GetComponent<PanelControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(gameObject.name + " just hit " + other.name);

        if (other.name == Roboter.name)
        {
            // when roboter collides with goal
            _AudioSource.PlayOneShot(GoalSound);

            panelControl.UpdateItems(Items);
            
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
