﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    /// <summary>
    /// The player current amount of health
    /// </summary>
    [SerializeField]    private int currentHealth;
    /// <summary>
    /// The player maximum amount of health
    /// </summary>
    [SerializeField]    private int maxHealth;

    public void Awake()
    {
        this.currentHealth = this.getMaxHealth();
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
        
        currentHealth -= damage;
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
        this.gameObject.SetActive(false);
        GetComponentInChildren<Animator>().SetTrigger("youDie");
        return Mathf.Abs(this.currentHealth);
        
    }
}
