using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipIntro : MonoBehaviour
{
    public GameObject Intro;
    public GameObject CameraIntro;
    public GameObject Eclairage;

    public float introskip = 0;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (Intro.activeInHierarchy == false && introskip == 0)
        {
            Destroy(CameraIntro);
            Eclairage.SetActive(true);
            ++introskip;
        }
    }
}
