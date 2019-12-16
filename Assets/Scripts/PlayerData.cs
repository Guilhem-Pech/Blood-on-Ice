using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerColor {Green,Orange}
public class PlayerData : MonoBehaviour
{
    [SerializeField] private GameObject playerSprite;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerAttackSystem playerAttackSystem;
    [SerializeField] private PlayerHealthSystem playerHealthSystem;
    [SerializeField] private SpotlightPlayer playerSpotlightPlayer;
    [SerializeField] private Material trailMaterial;
    [SerializeField] private PlayerColor _playerColor;
    
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

    public SpotlightPlayer GetSpotlightPlayer()
    {
        return playerSpotlightPlayer;
    }
    
    public GameObject GetPlayerSpriteGameObject()
    {
        return playerSprite;
    }

    public PlayerColor GetPlayerColor()
    {
        return _playerColor;
    }

    public void SetPlayerColor(PlayerColor playerColor)
    {
        _playerColor = playerColor;
        if (playerColor == PlayerColor.Green)
        {
            GetPlayerSpriteGameObject().GetComponent<Animator>().runtimeAnimatorController =
                GameManager.GetInstance().GetPlayersAnimator()[0];
            trailMaterial = GameManager.GetInstance().trailGreen;
        }
        else
        {
            GetPlayerSpriteGameObject().GetComponent<Animator>().runtimeAnimatorController =
                GameManager.GetInstance().GetPlayersAnimator()[1];
            trailMaterial = GameManager.GetInstance().trailOrange;
        }
        GetPlayerController().GetTrailRenderer().material = trailMaterial;
    }

    public Material GetTrailMaterial()
    {
        return trailMaterial;
    }

    public void DeactivateAll()
    {
        GetPlayerSpriteGameObject().SetActive(false);
        GetPlayerController().enabled = false;
        GetPlayerHealthSystem().enabled = false;
        GetPlayerAttackSystem().enabled = false;
        GetSpotlightPlayer().enabled = false;
    }
    
    public void ActivateAll()
    {
        GetPlayerSpriteGameObject().SetActive(true);
        GetPlayerController().enabled = true;
        GetPlayerHealthSystem().enabled = true;
        GetPlayerAttackSystem().enabled = true;
        GetSpotlightPlayer().enabled = true;
    }
}
