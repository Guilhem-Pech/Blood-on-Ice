using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
            List<GameObject> players = new List<GameObject>(GameManager.GetInstance().GetPlayers());
            
            AkSoundEngine.PostEvent("Voice_Fight", animator.gameObject);
            
            players[0].transform.SetPositionAndRotation(GameManager.GetInstance().playerGreenSpawnPos.transform.position, Quaternion.identity);
            players[1].transform.SetPositionAndRotation(GameManager.GetInstance().playerOrangeSpawnPos.transform.position, Quaternion.identity);
            
            animator.SetTrigger(StartRound);
        }


        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (GameObject ply in _players)
            {
                ply.GetComponent<PlayerData>().ActivateAll();
                GameManager.GetInstance().SpawnProjector(ply);
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