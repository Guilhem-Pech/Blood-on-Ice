using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealthSystem))]
public class PlayerAttackSystem : MonoBehaviour
{
    [SerializeField] [Range(1, 100)]
    [Tooltip("Percentage value of the knockback power.")] 
    private int forceOfKnockback;

    [SerializeField] [Range(0, 5)]
    [Tooltip("Percentage value of the knockback power.")] 
    private float velocityTrigger;

    void Update()
    {
        
    }


    /// <summary>
    /// Trigger the front attack of the player
    /// </summary>
    public void FrontAttack()
    {

    }

    /// <summary>
    /// Trigger the Area Of Effect attack of the player
    /// </summary>
    public void AOEAttack()
    {
        int layerMask = 1 << 9;
        Collider2D[] players = null;
        players = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 2, layerMask);
        Collider2D player= null;
        foreach (var item in players)
        {
            if(!item.Equals(this))
            {
                player = item;
            }
        }
        if (player !=null)
        {
            Vector2 direction = new Vector2((player.transform.position.x - transform.position.x), (player.transform.position.y - transform.position.y));
            player.attachedRigidbody.AddForce(direction * 0.01f * forceOfKnockback, ForceMode2D.Impulse);
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
            collision.otherCollider.gameObject.GetComponent<PlayerHealthSystem>();
        }
    }
}
