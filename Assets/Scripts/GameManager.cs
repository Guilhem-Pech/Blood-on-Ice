using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private HashSet<GameObject> _playerSet;
    
    private static GameManager _instance;
    
    public GameManager GetInstance()
    {
        return _instance; 
    }

    public void RegisterPlayer(GameObject playerObject)
    {
        if(!_playerSet.Add(playerObject))
            Debug.LogWarning("Trying to register a Player who's already registered !",this);
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
        DontDestroyOnLoad( this.gameObject );
    }
    
    
}
