using UnityEngine;

namespace Unity.LEGO.Minifig
{

    public class SpecialAnimationBehaviorJ : StateMachineBehaviour
    {
        int playSpecialHash = Animator.StringToHash("Play Special");

        MinifigControllerJ minifigController;

        override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            animator.SetBool(playSpecialHash, false);
            if (!minifigController)
            {
                minifigController = animator.transform.parent.GetComponent<MinifigControllerJ>();
            }

        }

        public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
        {
            minifigController.SpecialAnimationFinished();
        }
    }

}