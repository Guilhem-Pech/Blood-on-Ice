using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOnEvent : MonoBehaviour
{
    
    [SerializeField] private GameObject particulesPrefab;
    private ParticleSystem particules;

    void Awake()
    {
        particules = particulesPrefab.GetComponent<ParticleSystem>();
    }

    void OnEvent()
    {
        particules.Play();
        Debug.Log("\nKRSSSHHH!!!");
        //Son
    }
}
