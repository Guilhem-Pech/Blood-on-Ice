using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{

    public class Music : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            AkSoundEngine.PostEvent("Play_Music", animator.gameObject);
        }


        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}
