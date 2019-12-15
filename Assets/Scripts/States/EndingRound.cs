using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class EndingRound : StateMachineBehaviour
    {
        private static readonly int EndGame = Animator.StringToHash("EndGame");
        
        private HashSet<GameObject> _players;
        private static readonly int StartRound = Animator.StringToHash("StartRound");
        private static readonly int Player1Wins = Animator.StringToHash("Player1Wins");
        private static readonly int Player2Wins = Animator.StringToHash("Player2Wins");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            
            _players = GameManager.GetInstance().GetPlayers();
            
            GameManager.GetInstance().OnEndingRoundEvent().Invoke();
            
            foreach (GameObject ply in _players)
            {
                var plyData = ply.GetComponent<PlayerData>();
                Destroy(plyData.GetSpotlightPlayer().GetProjectorRuntime());
                plyData.DeactivateAll();
                plyData.GetPlayerLifeBar().SetActive(false);
            }
            
            if(animator.GetInteger(Player1Wins) > GameManager.GetInstance().GetNbRound() - 1 ||  animator.GetInteger(Player2Wins) > GameManager.GetInstance().GetNbRound() - 1)
                animator.SetTrigger(EndGame);
            else
                animator.SetTrigger(StartRound);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            
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