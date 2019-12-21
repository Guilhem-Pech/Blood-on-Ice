using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SkipIntro : MonoBehaviour
{
    [FormerlySerializedAs("Intro")] public GameObject intro;
    [FormerlySerializedAs("CameraIntro")] public GameObject cameraIntro;
    [FormerlySerializedAs("Eclairage")] public GameObject eclairage;

    public int introskip = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (intro.activeInHierarchy != false || introskip != 0) return;
        Destroy(cameraIntro);
        eclairage.SetActive(true);
        ++introskip;
    }
}
