using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOnEvent : MonoBehaviour
{
    public delegate void Pas();
    public event Pas OnPas;
    [SerializeField] private GameObject particulesPrefab;
    private ParticleSystem particules;

    void Awake()
    {
        particules = particulesPrefab.GetComponent<ParticleSystem>();
        OnPas += OnEvent;
    }

    public void OnEvent()
    {
        particules.Play();
        Debug.Log("KRSSSHHH!!!");
        //Son
    }
}
