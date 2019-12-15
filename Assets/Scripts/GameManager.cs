using System;
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
    [SerializeField]
    private int nbRound = 3;
    private static GameManager _instance;
    public CinemachineTargetGroup targetGroup;
    private Animator _animator;
    private int _playerCount = 0;
    public GameObject introPrefab;
    
    private PlayerEvent _playerAddEvent = new PlayerEvent ();
    private PlayerEvent _playerKilledEvent = new PlayerEvent();
    public GameObject projectorPrefab;
    public Transform playerGreenSpawnPos;
    public Transform playerOrangeSpawnPos;
    public GameObject[] lifeBars;
    public GameObject canvasTitle;
    public GameObject victoryScreen;
    private UnityEvent EndRound = new UnityEvent();
    
    
    public int GetNbRound()
    {
        return Math.Abs(nbRound);
    }
    
    [SerializeField]
    private List<AnimatorOverrideController> playersAnimator;
    
    public Transform spotLightAnchor1;    
    public Transform spotLightAnchor2;
    private static readonly int NbPlayers = Animator.StringToHash("nbPlayers");

    public List<AnimatorOverrideController> GetPlayersAnimator()
    {
        return playersAnimator;
    }

    public UnityEvent OnEndingRoundEvent()
    {
        return EndRound;
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
        targetGroup.AddMember(playerObject.GetComponent<PlayerController>().GetHeadTransform(),1f,2f);
        playerObject.GetComponent<PlayerData>().SetPlayerLifeBar(lifeBars[_playerCount % 2]); 
        
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
        _playerAddEvent.Invoke(playerInput.gameObject);
    }
    
    public void SpawnProjector(GameObject player)
    {
        GameObject projector = Instantiate(projectorPrefab);
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
}
