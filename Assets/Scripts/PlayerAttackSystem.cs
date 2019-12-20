using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(PlayerHealthSystem))]
public class PlayerAttackSystem : MonoBehaviour
{
    [SerializeField] [Range(1, 1000)]
    [Tooltip("Percentage value of the knockback power.")] 
    private int forceOfKnockback = 100;

    [SerializeField] [Range(0, 5)]
    [Tooltip("Percentage value of the knockback power.")] 
    private float velocityTrigger = 5;

    [SerializeField] [Range(1, 5)]
    [Tooltip("Radius of the knockback attack.")]
    private float radius = 1;

    [FormerlySerializedAs("AOECooldown")]
    [SerializeField]
    [Range(1, 5)]
    [Tooltip("Radius of the knockback attack.")]
    private float aoeCooldown = 1;
    private float _aoeCountdown;
    

    [FormerlySerializedAs("DashCooldown")]
    [SerializeField] [Range(1, 5)]
    [Tooltip("Radius of the knockback attack.")]
    private float dashCooldown = 1;
    private float _dashCountdown;

    private GameObject _playerToPush;
    private Vector2 _directionToPush;
    private bool _pushed;
    private float _actualVelocity;

    private Animator _animator;

    void Awake()
    {
        this._animator = this.GetComponentInChildren<Animator>();
        _dashCountdown = dashCooldown;
        _aoeCountdown = aoeCooldown;
    }

    private void OnEnable()
    {
        this._animator = this.GetComponentInChildren<Animator>();
    }

    private Animator GetAnimator()
    {
        return GetComponentInChildren<Animator>();
    }
    /// <summary>
    /// Trigger the front attack of the player
    /// </summary>
    public void FrontAttack()
    {
        if (_dashCountdown > 0)
        {
            return;
        }
        _animator.SetTrigger("HighAttack");
        AkSoundEngine.PostEvent("Dash_Attack", this.gameObject);
        AkSoundEngine.PostEvent("Attack_High", this.gameObject);
        AkSoundEngine.PostEvent("Voice_Attack", this.gameObject);
        this.GetComponent<Rigidbody2D>().AddForce((this.GetComponent<Rigidbody2D>().velocity.normalized)*5, ForceMode2D.Impulse);
        _dashCountdown = dashCooldown;
    }

    /// <summary>
    /// Trigger the knockback of the player
    /// </summary>
    public void AoeAttack()
    {
        if(_aoeCountdown > 0)
        {
            return;
        }
        _animator.SetTrigger("LowAttack");
        AkSoundEngine.PostEvent("Attack_Low", this.gameObject);
        AkSoundEngine.PostEvent("Voice_Attack", this.gameObject);
        int layerMask = 1 << 9;
        Collider2D[] players = null;
        players = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), radius, layerMask);
        Collider2D player= null;
        foreach (var item in players)
        {
            if (!item.Equals(this.GetComponentInChildren<Collider2D>()))
            {
                player = item;
            }
        }
        if (player !=null)
        {
            _playerToPush = player.transform.parent.gameObject;
            StartCoroutine(StartVibrate(0.1f));
            Vector2 direction = new Vector2((player.transform.parent.position.x - transform.position.x), (player.transform.parent.position.y - transform.position.y));
            direction = direction.normalized;
            _directionToPush = direction;
            _playerToPush.GetComponent<Rigidbody2D>().AddForce(forceOfKnockback * 0.03f * _directionToPush, ForceMode2D.Impulse);
            _playerToPush.GetComponent<PlayerHealthSystem>().TakeDamage(13);
            AkSoundEngine.PostEvent("Punchs", this.gameObject);
            _pushed = true;
        }
        _aoeCountdown = aoeCooldown;
    }


    private IEnumerator StartVibrate(float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<GamepadVibrate>()?.Vibrate(0.4f,0.4f,0.15f);
    }

    /// <summary>
    /// Triggered when two entities collide with each other
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        AkSoundEngine.PostEvent("Players_Collision", this.gameObject);
        try
        {
            if (!(this._actualVelocity > velocityTrigger)) return;
            if (collision.collider.gameObject.GetComponentInParent<PlayerHealthSystem>() != null)
            {
                collision.collider.gameObject.GetComponentInParent<PlayerHealthSystem>().TakeDamage(7);
                StartCoroutine(StartVibrate(0.05f));
                AkSoundEngine.PostEvent("Fit_Kick_Choc", this.gameObject);
            }
        }
        catch (NullReferenceException e)
        {}
    }

    void FixedUpdate()
    {
        _actualVelocity = this.GetComponent<Rigidbody2D>().velocity.magnitude;
    }

    void Update()
    {
        if(_aoeCountdown > 0)
        {
            _aoeCountdown -= Time.deltaTime;
        }
        if (_dashCountdown > 0)
        {
            _dashCountdown -= Time.deltaTime;
        }
    }
}
