using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOnEvent : MonoBehaviour
{
    public delegate void Pas();
    public event Pas OnPas;
    void Awake()
    {
        OnPas += OnEvent;
    }

    void OnEvent()
    {
        //Particules
        //Son
    }
}
