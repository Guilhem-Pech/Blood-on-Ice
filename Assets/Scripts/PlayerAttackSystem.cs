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
        players = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 2, layerMask);
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
            Vector2 direction = new Vector2((player.transform.position.x - transform.position.x), (player.transform.position.y - transform.position.y)).normalized;
            Debug.Log("c", this);
            player.GetComponentInParent<PlayerHealthSystem>().takeDamage(10);
            player.GetComponentInParent<Rigidbody2D>().AddForce(forceOfKnockback * 0.01f * direction, ForceMode2D.Impulse);
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
}
