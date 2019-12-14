using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class OnWaitingForPlayers : StateMachineBehaviour
    {
        private Animator _animator;
        private static readonly int StartRound = Animator.StringToHash("StartRound");
        private PlayerAddedEvent _playerAddedEvent;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _animator = animator;
            _playerAddedEvent = GameManager.GetInstance().GetPlayerAddedEvent();
            _playerAddedEvent.AddListener(OnPlayerAdded);
        }

        private void OnPlayerAdded(GameObject player)
        {
            if(GameManager.GetInstance().GetPlayersWaiting().Count >= 2)
                _animator.SetTrigger(StartRound);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _playerAddedEvent.RemoveListener(OnPlayerAdded);
        }
    }

}
