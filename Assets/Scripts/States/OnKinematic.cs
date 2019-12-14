using UnityEngine;

namespace States
{
    public class OnKinematic : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GameManager.GetInstance().introPrefab.SetActive(true);
        }
    }
}
