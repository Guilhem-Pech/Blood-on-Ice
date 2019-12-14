using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class EndingRound : StateMachineBehaviour
    {
        private static readonly int EndGame = Animator.StringToHash("EndGame");
        
        private HashSet<GameObject> _players;
        private HashSet<GameObject> _playersWaiting;
        private static readonly int StartRound = Animator.StringToHash("StartRound");
        private static readonly int RoundNumber = Animator.StringToHash("RoundNumber");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _players = GameManager.GetInstance().GetPlayers();
            _playersWaiting = GameManager.GetInstance().GetPlayersWaiting();
            _playersWaiting.Clear(); // I don't know why I need to do this, but there was the players in the hashset O_o 

            foreach (GameObject ply in _players)
            {
                Destroy(ply);
            }
            _players.Clear();

            animator.SetTrigger(animator.GetInteger(RoundNumber) <= GameManager.GetInstance().GetNbRound() - 1 ? StartRound : EndGame);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _players.Clear();
            for (int i = 0; i < 2; i++)
            {
                GameManager.GetInstance().SpawnPlayerWaiting();
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