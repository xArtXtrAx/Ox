using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    ParticleSystem[] _particleSystems;

    // Start is called before the first frame update
    void Start()
    {
        _particleSystems = GetComponentsInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        foreach (ParticleSystem p in _particleSystems)
        {
            p.Stop();
            p.Play();
        }
    }
    
}
