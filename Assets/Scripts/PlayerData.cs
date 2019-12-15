using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private GameObject playerSprite;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerAttackSystem playerAttackSystem;
    [SerializeField] private PlayerHealthSystem playerHealthSystem;



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
    }
    
    public void ActivateAll()
    {
        GetPlayerSpriteGameObject().SetActive(true);
        GetPlayerController().enabled = true;
        GetPlayerHealthSystem().enabled = true;
        GetPlayerAttackSystem().enabled = true;
    }
}
