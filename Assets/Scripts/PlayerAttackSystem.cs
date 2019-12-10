using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealthSystem))]
public class PlayerAttackSystem : MonoBehaviour
{
    [SerializeField] [Range(1, 100)]
    [Tooltip("Percentage value of the knockback power.")] 
    private int forceOfKnockback = 100;

    [SerializeField] [Range(0, 5)]
    [Tooltip("Percentage value of the knockback power.")] 
    private float velocityTrigger = 5;

    private GameObject _playerToPush;
    private Vector2 _directionToPush;
    private bool pushed;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.AOEAttack();
        }
    }


    /// <summary>
    /// Trigger the front attack of the player
    /// </summary>
    public void FrontAttack()
    {
        this.GetComponent<Rigidbody2D>().AddForce((this.GetComponent<Rigidbody2D>().velocity.normalized)*5, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Trigger the knockback of the player
    /// </summary>
    public void AOEAttack()
    {
        int layerMask = 1 << 9;
        Collider2D[] players = null;
        players = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 1, layerMask);
        Collider2D player= null;
        foreach (var item in players)
        {
            if (!item.Equals(this))
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
            pushed = true;
            //player.GetComponentInParent<PlayerHealthSystem>().takeDamage(10);
            //player.GetComponentInParent<Rigidbody2D>().AddForce(forceOfKnockback * 0.01f * direction, ForceMode2D.Impulse);
            //Debug.Log(player);
            Debug.Log(direction);
        }
    }


    /// <summary>
    /// Triggered when two entities collide with each other
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > velocityTrigger)
        {
            //collision.otherCollider.gameObject.GetComponent<PlayerHealthSystem>().takeDamage(10);
        }
    }

    void FixedUpdate()
    {
        if (pushed)
        {
            _playerToPush.GetComponent<Rigidbody2D>().AddForce(forceOfKnockback * 0.03f * _directionToPush, ForceMode2D.Impulse);
            _playerToPush.GetComponent<PlayerHealthSystem>().takeDamage(10);
            pushed = false;
        }
        else
        {
            _playerToPush = null;
        }
        
    }
}
