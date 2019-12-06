using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    private HashSet<GameObject> _playerSet = new HashSet<GameObject>();
    private static LobbyManager _instance;

    [SerializeField] [CanBeNull] private TextMeshProUGUI countOfPlayers;
    [SerializeField] private TextMeshProUGUI countDownGame;
    [SerializeField] private GameObject[] iconPlayers;
    

    public static LobbyManager GetInstance()
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
        countOfPlayers.text = $"{_playerSet.Count} / 2 Players";
        iconPlayers[_playerSet.Count-1].SetActive(true);
        if (_playerSet.Count >= 2) StartCoroutine(StartCountDownGame(0));
    }

    private IEnumerator StartCountDownGame(float time)
    {
        countDownGame.gameObject.SetActive(true);
        float cur = 0;
        while (cur <= time)
        {
            countDownGame.text = $"Game Starting in {time - cur}";
            yield return new WaitForSeconds(1);
            ++cur;
        }
        StartGame();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
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
