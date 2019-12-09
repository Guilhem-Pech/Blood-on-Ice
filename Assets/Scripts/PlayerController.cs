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
    private bool _facingRight = false;
    private Vector2 _inputDir;
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    private PlayerAttackSystem _attackSystem;
    private PlayerInput _playerInput;
    private Vector2 _projectorVelocity = Vector2.zero;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject trailPrefab;
    [SerializeField] Vector3 trailOffset = Vector2.zero;

    [SerializeField] private Collider2D trailCollider;
    
    private Animator _animator;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        spriteRenderer.enabled = true;
        GameManager.GetInstance().RegisterPlayer(gameObject);
        gameObject.layer = 9;
        Vector3 position = transform.position;
        projectorLight = Instantiate(projectorLight,position,Quaternion.identity);
        trailPrefab = Instantiate(trailPrefab, position, quaternion.identity);
        trailPrefab.GetComponent<PlayerHoles>()._playerCollider2D = trailCollider;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _attackSystem = GetComponent<PlayerAttackSystem>();
        _playerInput = GetComponent<PlayerInput>();

        _playerInput.actions.FindActionMap("PlayersControls").FindAction("Attack1").started += OnAttack1;
        _playerInput.actions.FindActionMap("PlayersControls").FindAction("Attack2").started += OnAttack2;
    }

    public void OnMovements(InputAction.CallbackContext context)
    {
        _inputDir = context.ReadValue<Vector2>();
    }
    
    void Flip ()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
    private void Update()
    {
        Vector3 position = transform.position;
        projectorLight.transform.position = Vector2.SmoothDamp(projectorLight.transform.position, position + projectorOffset, ref _projectorVelocity, smoothTime);
        trailPrefab.transform.SetPositionAndRotation(position + trailOffset,transform.rotation);
        
        _animator.SetBool(IsWalking, _rigidbody2D.velocity.sqrMagnitude > 0.5f);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.AddForce(_inputDir * force);
        if(_rigidbody2D.velocity.x > 0.1 && !_facingRight)
            Flip();
        else if(_rigidbody2D.velocity.x  < - 0.1 && _facingRight)
            Flip();
        
    }

    private void OnDestroy()
    {
        Destroy(projectorLight);
        GameManager.GetInstance().RemovePlayer(gameObject);
    }

    public void OnAttack1(InputAction.CallbackContext context)
    {
        _attackSystem.AOEAttack();
    }

    public void OnAttack2(InputAction.CallbackContext context)
    {
        _attackSystem.FrontAttack();
    }
}
