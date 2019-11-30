using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerLobby : MonoBehaviour
{
    public SceneAsset lobbyScene;
    [SerializeField]
    private PlayerController playerController;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
        LobbyManager.GetInstance().RegisterPlayer(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void SceneManagerOnActiveSceneChanged(Scene old , Scene newest)
    {
        if (newest.name != lobbyScene.name)
        {
            this.enabled = false;
            playerController.enabled = true;
        }
    }
}
