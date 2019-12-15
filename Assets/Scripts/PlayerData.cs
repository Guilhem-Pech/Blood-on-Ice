using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private GameObject playerSprite;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerAttackSystem playerAttackSystem;
    [SerializeField] private PlayerHealthSystem playerHealthSystem;
    [SerializeField] private SpotlightPlayer playerSpotlightPlayer;
    
    private GameObject playerLifebar;

    public GameObject GetPlayerLifeBar()
    {
        return playerLifebar;
    }
    
    public void SetPlayerLifeBar(GameObject lifebar)
    {
        playerLifebar = lifebar;
    }

    public PlayerController GetPlayerController()
    {
        return playerController;
    }
    
    public PlayerAttackSystem GetPlayerAttackSystem()
    {
        return playerAttackSystem;
    }
    public PlayerHealthSystem GetPlayerHealthSystem()
    {
        return playerHealthSystem;
    }

    public SpotlightPlayer getSpotlightPlayer()
    {
        return playerSpotlightPlayer;
    }
    
    public GameObject GetPlayerSpriteGameObject()
    {
        return playerSprite;
    }
    
    

    public void DeactivateAll()
    {
        GetPlayerSpriteGameObject().SetActive(false);
        GetPlayerController().enabled = false;
        GetPlayerHealthSystem().enabled = false;
        GetPlayerAttackSystem().enabled = false;
        getSpotlightPlayer().enabled = false;
    }
    
    public void ActivateAll()
    {
        GetPlayerSpriteGameObject().SetActive(true);
        GetPlayerController().enabled = true;
        GetPlayerHealthSystem().enabled = true;
        GetPlayerAttackSystem().enabled = true;
        getSpotlightPlayer().enabled = true;
    }
}
