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

    public void PlayFootstep1()
    { 
       AkSoundEngine.PostEvent($"Play_Deplacement_01", gameObject);
    }
    public void PlayFootstep2()
    { 
        AkSoundEngine.PostEvent($"Play_Deplacement_02", gameObject);
    }
}

