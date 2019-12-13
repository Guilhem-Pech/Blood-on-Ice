using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField]
    private int playerIndex = 0;
    
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }

    public void PlayFootstep()
    { 
       AkSoundEngine.PostEvent($"Play_Deplacements_J{(_playerController.GetPlayerIndex() + 1)}", gameObject);
    }
}

