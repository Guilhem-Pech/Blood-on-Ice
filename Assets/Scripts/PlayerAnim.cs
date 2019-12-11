using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    
    public void PlayFootstep()
    {
       // AkSoundengine.PostEvent(myEvent, gameObject)    
       AkSoundEngine.PostEvent("SFX_Deplacements", gameObject);
    }
}

