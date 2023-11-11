using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateParticleOnVoidEvent : MonoBehaviour
{
    [SerializeField] private VoidEventSO voidEvent;
    [SerializeField] private new List<ParticleSystem> particleSystem;

    private void OnEnable() 
    {
        voidEvent.OnEventRaised += PlayParticles;
    }

    private void OnDisable()
    {
        voidEvent.OnEventRaised -= PlayParticles;
    }

    private void PlayParticles()
    {
        for(int i = 0; i < particleSystem.Count; i++)
        {
            particleSystem[i].Play();
        }
    }
}
