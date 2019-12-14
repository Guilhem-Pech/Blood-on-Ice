using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private GameObject _playerToPush;
    private Vector2 _directionToPush;
    private bool pushed;
    private float actualVelocity;

    private Animator animator;

    void Awake()
    {
        this.animator = this.GetComponentInChildren<Animator>();
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
        GetAnimator().SetTrigger("HighAttack");
        this.GetComponent<Rigidbody2D>().AddForce((this.GetComponent<Rigidbody2D>().velocity.normalized)*5, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Trigger the knockback of the player
    /// </summary>
    public void AOEAttack()
    {
        GetAnimator().SetTrigger("LowAttack");
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
            Vector2 direction = new Vector2((player.transform.parent.position.x - transform.position.x), (player.transform.parent.position.y - transform.position.y));
            direction = direction.normalized;
            _directionToPush = direction;
            _playerToPush.GetComponent<Rigidbody2D>().AddForce(forceOfKnockback * 0.03f * _directionToPush, ForceMode2D.Impulse);
            _playerToPush.GetComponent<PlayerHealthSystem>().takeDamage(10);
            pushed = true;
        }
    }


    /// <summary>
    /// Triggered when two entities collide with each other
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            if (!(this.actualVelocity > velocityTrigger)) return;
            if (collision.collider.gameObject.GetComponentInParent<PlayerHealthSystem>() != null)
                collision.collider.gameObject.GetComponentInParent<PlayerHealthSystem>().takeDamage(10);
        }
        catch (NullReferenceException e)
        {}
    }

    void FixedUpdate()
    {
        actualVelocity = this.GetComponent<Rigidbody2D>().velocity.magnitude;
    }
}
