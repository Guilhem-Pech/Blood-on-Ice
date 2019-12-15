using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

[RequireComponent(typeof(Collider2D))]
public class CollideVibrate : MonoBehaviour
{
  public float timeMotor = 0.7f;
  
  public float lowFrequency = 0.5f;
  public float highFrequency = 0.5f;

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (CameraManager.Instance != null) CameraManager.Instance.Shake(0.5f, 0.5f, timeMotor);
    other.gameObject.GetComponent<GamepadVibrate>().Vibrate(lowFrequency,highFrequency,timeMotor);
  }


  private void OnCollisionExit2D(Collision2D other)
  {
    other.gameObject.GetComponent<GamepadVibrate>().StopVibrations();
  }
  
}

