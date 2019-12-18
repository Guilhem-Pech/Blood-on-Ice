using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class OnWaitingForPlayers : StateMachineBehaviour
    {
        private Animator _animator;
        private static readonly int StartRound = Animator.StringToHash("StartRound");
        private static readonly int IntroSkipped = Animator.StringToHash("IntroSkipped");
        private PlayerEvent _playerEvent;
        private GameObject _canvasTitle;
        private int _nbPlayer = 0;
        private static readonly int NbPlayer = Animator.StringToHash("NbPlayer");
        private bool _start = false;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _nbPlayer = 0;
            _start = false;
            _animator = animator;
            _playerEvent = GameManager.GetInstance().GetPlayerAddedEvent();
            _playerEvent.AddListener(OnPlayerAdded);
            _canvasTitle = GameManager.GetInstance().canvasTitle;
            _canvasTitle.SetActive(true);
            AkSoundEngine.PostEvent("Play_Music_Menu_And_Cinematic", animator.gameObject);
        }

        private void OnPlayerAdded(GameObject player)
        {
            ++_nbPlayer;
            AkSoundEngine.PostEvent("Ice_Skates_Slide_Player_"+_nbPlayer, _animator.gameObject);
            _canvasTitle.GetComponent<Animator>().SetInteger(NbPlayer,_nbPlayer);
            player.GetComponent<PlayerData>().SetPlayerColor(_nbPlayer == 1 ? PlayerColor.Green : PlayerColor.Orange);
            GameManager.GetInstance().RegisterPlayer(player);
           if (_nbPlayer < 2) return;
            _start = true;
            AkSoundEngine.PostEvent("Break_Ice_When_Character_are_Ready", _animator.gameObject);

        }

        private bool _pass = true;
        private float _timeStart = 0.9f;
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if(!_start)
                return;
            _timeStart -= Time.deltaTime;
            
            _canvasTitle.GetComponent<Animator>().SetInteger(NbPlayer,_nbPlayer + 1);
            if (!(_timeStart <= 0f || !_pass)) return;
            _pass = true;

            if (GameObject.Find("Skip").GetComponent<SkipIntro>().introskip == 0)
            {
                _animator.SetTrigger(StartRound);
            }

            else
            {
                AkSoundEngine.StopAll();
                _animator.SetTrigger(IntroSkipped);
            }

        }


        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            PlayerInputManager.instance.joinBehavior = PlayerJoinBehavior.JoinPlayersManually;
            _playerEvent?.RemoveListener(OnPlayerAdded);
            _canvasTitle.SetActive(false);
        }
    }

}
