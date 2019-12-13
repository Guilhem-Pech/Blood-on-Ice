using UnityEngine;

namespace States.Players
{
    public class OnPlayerMove : StateMachineBehaviour
    {
   
        private PlayerController _playerController;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            _playerController = animator.GetComponentInParent<PlayerController>();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            AkSoundEngine.PostEvent($"Stop_Deplacements_J{(_playerController.GetPlayerIndex() + 1)}", animator.gameObject);
        }
    }
}
