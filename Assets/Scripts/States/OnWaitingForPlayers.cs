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
        private GameObject _canvasTitle;
        private int _nbPlayer = 0;
        private static readonly int NbPlayer = Animator.StringToHash("NbPlayer");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _animator = animator;
            _playerEvent = GameManager.GetInstance().GetPlayerAddedEvent();
            _playerEvent.AddListener(OnPlayerAdded);
            _canvasTitle = GameManager.GetInstance().canvasTitle;
            _canvasTitle.SetActive(true);
        }

        private bool _start = false;
        private void OnPlayerAdded(GameObject player)
        {
            ++_nbPlayer;
            _canvasTitle.GetComponent<Animator>().SetInteger(NbPlayer,_nbPlayer);
            if (GameManager.GetInstance().GetPlayersWaiting().Count >= 2)
                _start = true;

        }
        
        private float _timeStart = 2;
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if(!_start)
                return;
            _timeStart -= Time.deltaTime;
            _canvasTitle.GetComponent<Animator>().SetInteger(NbPlayer,_nbPlayer + 1);
           if(_timeStart <= 0f)
               _animator.SetTrigger(StartRound);
        }


        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            PlayerInputManager.instance.joinBehavior = PlayerJoinBehavior.JoinPlayersManually;
            _playerEvent.RemoveListener(OnPlayerAdded);
            _canvasTitle.SetActive(false);
        }
    }

}
