using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefendMiddleBehaviour : StateMachineBehaviour
{
    private MinifigControllerWTH playerController;
    private GameObject player;
    private Animator animator;
    private NavMeshPath currentPath;
    public float maxDistanceFromMiddle = 1.5f;
    public float playerDetectionDistance = 5f;
    private WhatTheHillGame game;
    private GameObject pickUpContainer;
    private GameObject ringMoveArrows;
    private bool hasBat = false;
    public float timeSinceLastHit = 2f;
    public float timeSinceLastMove = 6f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerController = animator.GetComponentInParent<MinifigControllerWTH>();
        player = animator.gameObject;
        this.animator = animator;

        game = GameObject.Find("WTHGameManger").GetComponent<WhatTheHillGame>();
        pickUpContainer = GameObject.Find("PowerUpSpawner");
        ringMoveArrows = GameObject.Find("RingMoveArrows");
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsInMiddle", isPlayerInMiddle(player.transform.position));
        if (timeSinceLastMove < 0 && playerController.state == MinifigControllerWTH.State.Idle)
        {
            Transform target = powerUpInRange(player.transform.position);
            if( target != null)
            {
                //go to pickup bat and use it
                currentPath = new NavMeshPath();
                NavMesh.CalculatePath(player.transform.position, target.position, NavMesh.AllAreas, currentPath);
                if (currentPath.corners.Length >= 2)
                {
                    if (Vector3.Distance(player.transform.position, currentPath.corners[1]) > 0.5f)
                    {
                        playerController.MoveTo(currentPath.corners[1]);
                    }
                }
                
            } else
            {
                Transform arrow = ringMoveArrows.transform.GetChild(Random.Range(0, ringMoveArrows.transform.childCount));
                currentPath = new NavMeshPath();
                NavMesh.CalculatePath(player.transform.position, arrow.position, NavMesh.AllAreas, currentPath);
                if (currentPath.corners.Length >= 2)
                {
                    if (Vector3.Distance(player.transform.position, currentPath.corners[1]) > 0.5f)
                    {
                        playerController.MoveTo(currentPath.corners[1]);
                    }
                }
            }
            timeSinceLastMove = 6f;
            hasBat = playerController.hasEquipment();
        }
        else if (playerInRange(player.transform.position) && hasBat)
        {
            // Hit player every x seconds
            if(timeSinceLastHit > 0f)
            {
                timeSinceLastHit -= Time.deltaTime;
            } else
            {
                playerController.HitWithBat();
                timeSinceLastHit = 2f;
                hasBat = playerController.hasEquipment();
            }
        } 
        timeSinceLastMove -= Time.deltaTime;
    }

    private bool isPlayerInMiddle(Vector3 position)
    {
        return Mathf.Abs(position.x) <= maxDistanceFromMiddle && Mathf.Abs(position.z) <= maxDistanceFromMiddle;
    }

    private Transform powerUpInRange(Vector3 myPosition)
    {
        foreach (Transform pickup in pickUpContainer.transform)
        {
            Vector3 distance = pickup.position - myPosition;
            if (distance.magnitude <= playerDetectionDistance) return pickup;
        }
        return null;
    }
    private bool playerInRange(Vector3 myPosition)
    {
        bool result = false;
        foreach (GameObject player in game.Players)
        {
            if (player != this.player)
            {
                Vector3 distance = player.transform.position - myPosition;
                if (distance.magnitude <= playerDetectionDistance) return true;
            }
        }
        return result;
    }
}
