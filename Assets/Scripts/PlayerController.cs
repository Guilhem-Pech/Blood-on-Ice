using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    
    // Configuration fields
    [SerializeField]
    private float force = 1;
    [SerializeField]
    private float smoothTime = 0.1F;
    
    [SerializeField]
    private GameObject projectorLight;
    
    // Start is called before the first frame update
    private Vector2 _inputDir;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _projectorVelocity = Vector3.zero;
    private void Start()
    {
        GameManager.GetInstance().RegisterPlayer(gameObject);
        projectorLight = Instantiate(projectorLight,transform.position,Quaternion.identity);
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void OnMovements(InputAction.CallbackContext context)
    {
       _inputDir = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        projectorLight.transform.position = Vector3.SmoothDamp(projectorLight.transform.position, transform.position, ref _projectorVelocity, smoothTime);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.AddForce(_inputDir * force);
    }

    private void OnDestroy()
    {
        Destroy(projectorLight);
        GameManager.GetInstance().RemovePlayer(gameObject);
    }
}
