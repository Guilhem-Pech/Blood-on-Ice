﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class PlayerHealthSystem : MonoBehaviour
{
    private bool _dead;
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
    

    private void OnEnable()
    {
        lifeBar = GetComponent<PlayerData>().GetPlayerLifeBar().GetComponent<LifeBar>();
        currentHealth = GetMaxHealth();
        _dead = false;
        lifeBar.lifePercent = 1.0f;
    }

    /// <summary>
    /// Returns the current health of a player
    /// </summary>
    /// <returns>The current health of a player</returns>
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    /// <summary>
    /// Returns the maximum health of a player
    /// </summary>
    /// <returns>The maximum health of a player</returns>
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    /// <summary>
    /// Decreases a player's health by [damage]
    /// </summary>
    /// <param name="damage">The amount of health to remove of the player</param>
    public void TakeDamage(int damage)
    {
        if (Random.Range(0, 3) > 0)
        {
            Transform t;
            GameObject blood = Instantiate(bloodPrebabs[Random.Range(0, 4)], (t = transform).position, t.rotation);
            Destroy(blood, 4f);
        }
        currentHealth -= damage;
        AkSoundEngine.PostEvent("Voice_Damage", this.gameObject);
        lifeBar.lifePercent = currentHealth / (float) maxHealth;
        if(currentHealth <= 0)
        {
            this.GetKilled();
            return;
        }
        GetComponentInChildren<Animator>().SetTrigger("takeDamage");
    }

    /// <summary>
    /// Kills a player
    /// </summary>
    /// <returns>The overkill amount</returns>
    public int GetKilled()
    {
        //Kill the player here
        GetComponentInChildren<Animator>().SetTrigger("youDie");
        AkSoundEngine.PostEvent("Player_Death_Voice", this.gameObject);
        AkSoundEngine.PostEvent("Player_Death_Fall", this.gameObject);
        return Mathf.Abs(this.currentHealth);
        
    }

    void Update()
    {
        if (GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PlayerOrange_Death"))
        {
            this._dead = true;
        }
        if (_dead)
        {
            if (GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PlayerOrange_Idle"))
            {
                GameManager.GetInstance().GetPlayerKilledEvent().Invoke(gameObject);
            }

        }
        
    }
}
