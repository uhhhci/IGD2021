using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MoveToMiddleBehaviour : StateMachineBehaviour
{
    private MinifigControllerWTH playerController;
    private GameObject player;
    private Animator animator;
    private NavMeshPath currentPath;
    public float maxDistanceFromMiddle = 1f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerController = animator.GetComponentInParent<MinifigControllerWTH>();
        player = animator.gameObject;
        this.animator = animator;
        Vector3 targetPosition = new Vector3(0, 0, 0);
        currentPath = new NavMeshPath(); 
        NavMesh.CalculatePath(player.transform.position, targetPosition, NavMesh.AllAreas, currentPath);
        for (int i = 0; i < currentPath.corners.Length - 1; i++)
            Debug.DrawLine(currentPath.corners[i], currentPath.corners[i + 1], Color.red);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsInMiddle", isPlayerInMiddle(player.transform.position));
    }

    private bool isPlayerInMiddle (Vector3 position)
    {
        return position.x <= maxDistanceFromMiddle && position.z <= maxDistanceFromMiddle;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
