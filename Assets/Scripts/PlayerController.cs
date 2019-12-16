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
    
    private bool _facingRight = false;
    private Vector2 _inputDir;
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    private PlayerAttackSystem _attackSystem;
    private PlayerInput _playerInput;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject trailPrefab;

    private GameObject _trailRuntime;
    [SerializeField] Vector3 trailOffset = Vector2.zero;
    
    [SerializeField] private Collider2D trailCollider;

  
    [SerializeField] private Transform headPos;
    
    private Animator _animator;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");


   
    public Transform GetHeadTransform()
    {
        return headPos;
    }
    public int GetPlayerIndex()
    {
        return _playerInput.playerIndex;
    }
    
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        spriteRenderer.enabled = true;
        gameObject.layer = 9;
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _attackSystem = GetComponent<PlayerAttackSystem>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        _trailRuntime = Instantiate(trailPrefab, position, quaternion.identity);
        _trailRuntime.GetComponent<PlayerHoles>().playerCollider2D = trailCollider;
        _trailRuntime.GetComponent<TrailRenderer>()?.Clear();
        _trailRuntime.GetComponent<TrailRenderer>().material = GetComponent<PlayerData>().GetTrailMaterial();
        // trailPrefab.SetActive(true);
    }

    private void OnDisable()
    {
        Destroy(_trailRuntime);
    }

    public void OnMovements(InputAction.CallbackContext context)
    {
        _inputDir = context.ReadValue<Vector2>();
    }

    public TrailRenderer GetTrailRenderer()
    {
        if (_trailRuntime != null) return _trailRuntime.GetComponent<TrailRenderer>();
        return trailPrefab.GetComponent<TrailRenderer>();
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

        _trailRuntime.transform.SetPositionAndRotation(position + trailOffset,transform.rotation);
        
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
        //GameManager.GetInstance().RemovePlayer(gameObject);
    }

    public void OnAttack1(InputAction.CallbackContext context)
    {
        if(context.started)
            _attackSystem.AOEAttack();
    }

    public void OnAttack2(InputAction.CallbackContext context)
    {
        if(context.started)
            _attackSystem.FrontAttack();
    }
}
