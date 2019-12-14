using UnityEngine;

namespace States
{
    public class EndGame : StateMachineBehaviour
    {
        private GameObject _victoryScreen;
        private static readonly int Player1Wins = Animator.StringToHash("Player1Wins");
        private static readonly int Player2Wins = Animator.StringToHash("Player2Wins");
        private static readonly int VictoriousPlayer = Animator.StringToHash("VictoriousPlayer");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _victoryScreen = GameManager.GetInstance().victoryScreen;
            int ply1Wins = animator.GetInteger(Player1Wins);
            int ply2Wins = animator.GetInteger(Player2Wins);
            
            if(ply1Wins > ply2Wins)
            {
                _victoryScreen.GetComponent<Animator>().SetInteger(VictoriousPlayer,1);
                AkSoundEngine.PostEvent("Voice_Player_1_Wins", animator.gameObject);
            }
            else
            {
                _victoryScreen.GetComponent<Animator>().SetInteger(VictoriousPlayer,2);
                AkSoundEngine.PostEvent("Voice_Player_2_Wins", animator.gameObject);
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
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