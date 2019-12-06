﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

[RequireComponent(typeof(Collider2D))]
public class CollideVibrate : MonoBehaviour
{
  public float timeMotor = 0.7f;
  private ReadOnlyArray<InputDevice> _devices;

  private void OnCollisionEnter2D(Collision2D other)
  {
    _devices = other.gameObject.GetComponent<PlayerInput>().devices;
    Gamepad gamepadFromDevices = GetGamepadFromDevices(_devices);
    if(gamepadFromDevices == null)
      return;
    gamepadFromDevices.SetMotorSpeeds(1f,0);
    StartCoroutine(StopMotor(timeMotor,gamepadFromDevices));
  }

  private IEnumerator StopMotor(float time, Gamepad gamepad)
  {
    yield return new WaitForSeconds(time);
    gamepad.SetMotorSpeeds(0,0);
  }
  
  
  private static Gamepad GetGamepadFromDevices(ReadOnlyArray<InputDevice> inputDevice)
  {
    foreach (InputDevice device in inputDevice)
    {
      if (device is Gamepad gamepad)
        return gamepad;
    }

    return null;
  }
}
