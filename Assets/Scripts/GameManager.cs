using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor.Animations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private HashSet<GameObject> _playerSet = new HashSet<GameObject>();
    private static GameManager _instance;
    public CinemachineTargetGroup targetGroup;
    private Animator _animator;
    private static readonly int StartRound = Animator.StringToHash("StartRound");
    private int _playerCount = 0; 
    
    [SerializeField]
    private List<AnimatorOverrideController> playersAnimator;
    
    public Transform spotLightAnchor1;
    public Transform spotLightAnchor2;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger(StartRound);
        if (playersAnimator.Count < 0)
            Debug.LogError("Players' Animator not set in the Game Manager", this);
    }

    public static GameManager GetInstance()
    {
        return _instance; 
    }

    public void RegisterPlayer(GameObject playerObject)
    {
        if(!_playerSet.Add(playerObject))
        {
            Debug.LogWarning("Trying to register a Player who's already registered !",this);
            return;
        }
        targetGroup.AddMember(playerObject.transform,1f,1.4f);
        playerObject.GetComponentInChildren<Animator>().runtimeAnimatorController = playersAnimator[_playerCount % playersAnimator.Count];
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
