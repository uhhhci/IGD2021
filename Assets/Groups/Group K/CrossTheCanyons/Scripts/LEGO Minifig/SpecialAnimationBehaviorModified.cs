using UnityEngine;

namespace Unity.LEGO.Minifig
{

    public class SpecialAnimationBehaviorModified : StateMachineBehaviour
    {
        int playSpecialHash = Animator.StringToHash("Play Special");

        MinifigControllerModified minifigController;

        override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            animator.SetBool(playSpecialHash, false);
            if (!minifigController)
            {
                minifigController = animator.transform.parent.GetComponent<MinifigControllerModified>();
            }

        }

        public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
        {
            minifigController.SpecialAnimationFinished();
        }
    }

}