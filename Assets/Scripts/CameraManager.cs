﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraManager : MonoBehaviour
{

    public static CameraManager instance;
    public CinemachineVirtualCamera vmCam;

    private CinemachineBasicMultiChannelPerlin _noiseSettings;

    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _noiseSettings = vmCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(float amplitutde, float frequency, float timeInSeconds)
    {
        _noiseSettings.m_AmplitudeGain = amplitutde;
        _noiseSettings.m_FrequencyGain = frequency;
        StartCoroutine(StartScreenShake(timeInSeconds));
    }

    public void Vibrate(float low_frequency, float high_frequency, float timeInSeconds)
    {
        Gamepad.current.SetMotorSpeeds(low_frequency, high_frequency);
        StartCoroutine(StartVibrateController(timeInSeconds));
    }

    IEnumerator StartScreenShake(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        _noiseSettings.m_AmplitudeGain = 0;
        _noiseSettings.m_FrequencyGain = 0;
    }

    IEnumerator StartVibrateController(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        Gamepad.current.SetMotorSpeeds(0, 0);
    }
}
