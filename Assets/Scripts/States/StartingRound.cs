using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class StartingRound : StateMachineBehaviour
    {
        private static readonly int StartRound = Animator.StringToHash("StartRound");
        
        private HashSet<GameObject> _players;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _players = GameManager.GetInstance().GetPlayers();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (_players.Count >= 2 )
            {
                //TODO: Launch kinematic 
                animator.SetTrigger(StartRound);
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