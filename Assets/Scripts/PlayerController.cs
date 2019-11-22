using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    // Configuration fields
    [SerializeField]
    private float force = 1;
    
    
    // Start is called before the first frame update
    private Vector2 _inputDir;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void OnMovements(InputAction.CallbackContext context)
    {
       _inputDir = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.AddForce(_inputDir * force);
    }
}
