﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerHealthSystem : MonoBehaviour
{
    private bool dead;

    /// <summary>
    /// The player current amount of health
    /// </summary>
    [SerializeField]    private int currentHealth;
    /// <summary>
    /// The player maximum amount of health
    /// </summary>
    [SerializeField]    private int maxHealth;

    [SerializeField] private GameObject[] bloodPrebabs;


    public LifeBar lifeBar;
    
    public void Awake()
    {
        this.currentHealth = this.getMaxHealth();
        this.dead = false;
    }

    /// <summary>
    /// Returns the current health of a player
    /// </summary>
    /// <returns>The current health of a player</returns>
    public int getCurrentHealth()
    {
        return currentHealth;
    }

    /// <summary>
    /// Returns the maximum health of a player
    /// </summary>
    /// <returns>The maximum health of a player</returns>
    public int getMaxHealth()
    {
        return maxHealth;
    }

    /// <summary>
    /// Decreases a player's health by [damage]
    /// </summary>
    /// <param name="damage">The amount of health to remove of the player</param>
    public void takeDamage(int damage)
    {
        if (Random.Range(0, 3) > 0)
        {
            Transform t;
            GameObject blood = Instantiate(bloodPrebabs[Random.Range(0, 4)], (t = transform).position, t.rotation);
            Destroy(blood, 4f);
        }

        currentHealth -= damage;
        lifeBar.lifePercent = currentHealth / (float) maxHealth;
        if(currentHealth <= 0)
        {
            this.getKilled();
            return;
        }
        GetComponentInChildren<Animator>().SetTrigger("takeDamage");
    }

    /// <summary>
    /// Kills a player
    /// </summary>
    /// <returns>The overkill amount</returns>
    public int getKilled()
    {
        //Kill the player here
        GetComponentInChildren<Animator>().SetTrigger("youDie");
        return Mathf.Abs(this.currentHealth);
        
    }

    void Update()
    {
        if (GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName(""))
        {
            this.dead = true;
        }
        if (dead)
        {
            if (GetComponentInChildren<Animator>().IsInTransition(0))
            {
                GameManager.GetInstance().GetPlayerKilledEvent().Invoke(gameObject);
            }
        }
        
    }
}
