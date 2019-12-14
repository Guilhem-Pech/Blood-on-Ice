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
        private static readonly int Players2Win = Animator.StringToHash("Player2Wins");
        private static readonly int Players1Wins = Animator.StringToHash("Player1Wins");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _animator = animator;
            _players = GameManager.GetInstance().GetPlayers();
            GameManager.GetInstance().GetPlayerKilledEvent().AddListener(OnPlayerKilled);
        }


        private void OnPlayerKilled(GameObject player)
        {
            List<GameObject> plyList = new List<GameObject>(_players);
            if (plyList[0] == player)
                _animator.SetInteger(Players2Win, _animator.GetInteger(Players2Win) + 1 );
            else
                _animator.SetInteger(Players1Wins, _animator.GetInteger(Players1Wins) + 1);
            
            _animator.SetTrigger(EndRound);
        }
    }
}