using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace States
{
    public class OnGoingRound : StateMachineBehaviour
    {

        private HashSet<GameObject> _players;
        private Animator _animator;
        private static readonly int EndRound = Animator.StringToHash("EndRound");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _animator = animator;
            _players = GameManager.GetInstance().GetPlayers();
            GameManager.GetInstance().GetPlayerKilledEvent().AddListener(OnPlayerKilled);
        }


        private void OnPlayerKilled(GameObject player)
        {
            _animator.SetTrigger(EndRound);
        }
    }
}