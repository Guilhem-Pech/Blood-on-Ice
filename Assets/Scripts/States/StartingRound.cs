using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class StartingRound : StateMachineBehaviour
    {
        private static readonly int StartRound = Animator.StringToHash("StartRound");

        private HashSet<GameObject> _players;
        private HashSet<GameObject> _playersWaiting;
        private static readonly int RoundNumber = Animator.StringToHash("RoundNumber");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _playersWaiting = GameManager.GetInstance().GetPlayersWaiting();
            _players = GameManager.GetInstance().GetPlayers();
            animator.SetInteger(RoundNumber,animator.GetInteger(RoundNumber) + 1);
            foreach (GameObject gameObject in _playersWaiting)
            {
                Destroy(gameObject);
            }
            _playersWaiting.Clear();
            animator.SetTrigger(StartRound);
        }


        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            for (int i = 0; i < 2; i++)
            {
                GameManager.GetInstance().SpawnPlayer();
            }
        }

        /*
        public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
        }

        public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
        }
        */
    }
}