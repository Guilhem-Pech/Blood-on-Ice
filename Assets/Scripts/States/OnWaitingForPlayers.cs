using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class OnWaitingForPlayers : StateMachineBehaviour
    {
        private Animator _animator;
        private static readonly int StartRound = Animator.StringToHash("StartRound");
        private PlayerEvent _playerEvent;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _animator = animator;
            _playerEvent = GameManager.GetInstance().GetPlayerAddedEvent();
            _playerEvent.AddListener(OnPlayerAdded);
        }

        private void OnPlayerAdded(GameObject player)
        {
            if(GameManager.GetInstance().GetPlayersWaiting().Count >= 2)
                _animator.SetTrigger(StartRound);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            PlayerInputManager.instance.joinBehavior = PlayerJoinBehavior.JoinPlayersManually;
            _playerEvent.RemoveListener(OnPlayerAdded);
        }
    }

}
