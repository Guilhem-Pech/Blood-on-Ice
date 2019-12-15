using UnityEngine;
using UnityEngine.Animations;

namespace States
{
   
    public class OnKinematic : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GameManager.GetInstance().introPrefab.SetActive(true);
        }


        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            AkSoundEngine.PostEvent("Play_Music", animator.gameObject);
        }
    }
}
