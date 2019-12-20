using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SkipIntro : MonoBehaviour
{
    [FormerlySerializedAs("Intro")] public GameObject intro;
    [FormerlySerializedAs("CameraIntro")] public GameObject cameraIntro;
    [FormerlySerializedAs("Eclairage")] public GameObject eclairage;

    public float introskip = 0;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (intro.activeInHierarchy == false && introskip == 0)
        {
            Destroy(cameraIntro);
            eclairage.SetActive(true);
            ++introskip;
        }
    }
}
