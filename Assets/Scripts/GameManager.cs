﻿using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


[System.Serializable]
public class PlayerEvent : UnityEvent<GameObject>
{}

public class GameManager : MonoBehaviour
{
    private readonly HashSet<GameObject> _playerSet = new HashSet<GameObject>();
    private readonly HashSet<GameObject> _playersWaiting = new HashSet<GameObject>();
    [SerializeField]
    private int nbRound = 3;
    private static GameManager _instance;
    public CinemachineTargetGroup targetGroup;
    private Animator _animator;
    private int _playerCount = 0;
    public GameObject introPrefab;
    
    private PlayerEvent _playerAddEvent = new PlayerEvent ();
    private PlayerEvent _playerKilledEvent = new PlayerEvent();
    
    public GameObject playerWaitingPrefab;
    public GameObject playerGreenPrefab;
    public GameObject playerOrangePrefab;
    public GameObject projectorPrefab;
    public Transform playerGreenSpawnPos;
    public Transform playerOrangeSpawnPos;
    public GameObject[] lifeBars;
    public GameObject canvasTitle;
    public GameObject victoryScreen;
    
    public int GetNbRound()
    {
        return Math.Abs(nbRound);
    }
    
    [SerializeField]
    private List<AnimatorOverrideController> playersAnimator;
    
    public Transform spotLightAnchor1;    
    public Transform spotLightAnchor2;
    private static readonly int NbPlayers = Animator.StringToHash("nbPlayers");
    
    public HashSet<GameObject> GetPlayersWaiting()
    {
        return _playersWaiting;
    }
    private void Start()
    {
        
        _animator = GetComponent<Animator>();
        if (playersAnimator.Count < 0)
            Debug.LogError("Players' Animator not set in the Game Manager", this);
    }

    public static GameManager GetInstance()
    {
        return _instance; 
    }

    public PlayerEvent GetPlayerAddedEvent()
    {
        return _playerAddEvent;
    }

    public PlayerEvent GetPlayerKilledEvent()
    {
        return _playerKilledEvent; 
    }
    
    public void RegisterPlayer(GameObject playerObject)
    {
        if(!_playerSet.Add(playerObject))
        {
            Debug.LogWarning("Trying to register a Player who's already registered !",this);
            return;
        }
        targetGroup.AddMember(playerObject.transform,1f,1.4f);
        lifeBars[_playerCount % 2].SetActive(true);
        playerObject.GetComponent<PlayerHealthSystem>().lifeBar = lifeBars[_playerCount % 2].GetComponent<LifeBar>();
        ++_playerCount;
    }
    
    
    
    
    public void RemovePlayer(GameObject playerObject)
    {
        _playerSet.Remove(playerObject);
    }

    public HashSet<GameObject> GetPlayers()
    {
        return _playerSet;
    }


    public void InputPlayerJoinEvent(PlayerInput playerInput)
    {
        _playersWaiting.Add(playerInput.gameObject);
        _playerAddEvent.Invoke(playerInput.gameObject);
    }
    
    public void SpawnPlayer()
    {
        GameObject projector = Instantiate(projectorPrefab);
        
        GameObject player = _playerCount % 2 != 0 ? 
            Instantiate(playerGreenPrefab,playerGreenSpawnPos.position,playerGreenSpawnPos.rotation) 
            : Instantiate(playerOrangePrefab,playerOrangeSpawnPos.position,playerOrangeSpawnPos.rotation);
        
        RegisterPlayer(player);
        player.GetComponent<SpotlightPlayer>().SetProjectorRuntime(projector);
        

    }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }


    public void SpawnPlayerWaiting()
    {
        GameObject wPly = Instantiate(playerWaitingPrefab);
        _playersWaiting.Add(wPly);
    }
}
