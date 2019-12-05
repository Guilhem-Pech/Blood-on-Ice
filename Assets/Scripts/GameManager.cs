using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private HashSet<GameObject> _playerSet = new HashSet<GameObject>();
    private static GameManager _instance;
    public CinemachineTargetGroup targetGroup;
    private Animator _animator;
    private static readonly int StartRound = Animator.StringToHash("StartRound");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger(StartRound);
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
