using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOnEvent : MonoBehaviour
{
    
    [SerializeField] private GameObject particulesPrefab;
    private ParticleSystem _particules;

    void Awake()
    {
        _particules = particulesPrefab.GetComponent<ParticleSystem>();
    }

    public void OnEvent()
    {
        _particules.Play();
        //Son
    }
}
