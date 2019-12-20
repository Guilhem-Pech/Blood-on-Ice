using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOnEvent1 : MonoBehaviour
{
    
    [SerializeField] private GameObject particulesPrefab;
    private ParticleSystem _particules;

    void Awake()
    {
        _particules = particulesPrefab.GetComponent<ParticleSystem>();
    }

    public void OnEvent1()
    {
        _particules.Play();
        //Son
    }
}
