using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    
    [SerializeField]
    private Vector3 projectorOffset = Vector3.zero;
    
    private Vector2 _inputDir;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _projectorVelocity = Vector2.zero;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject trailPrefab;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        GameManager.GetInstance().RegisterPlayer(gameObject);
        projectorLight = Instantiate(projectorLight,transform.position,Quaternion.identity);
        trailPrefab = Instantiate(trailPrefab, transform.position, quaternion.identity);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void OnMovements(InputAction.CallbackContext context)
    {
       _inputDir = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        Vector3 position = transform.position;
        projectorLight.transform.position = Vector2.SmoothDamp(projectorLight.transform.position, position + projectorOffset, ref _projectorVelocity, smoothTime);
        trailPrefab.transform.SetPositionAndRotation(position,transform.rotation);
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
