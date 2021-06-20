﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIAgentR : MonoBehaviour
{
    public OurMinifigController player;
    private OurMinifigController target;
    public SmashGameR gameManager;

    public Animator animator;
    int atRightSideUpHash = Animator.StringToHash("atRightSideUp");
    int atLeftSideUpHash = Animator.StringToHash("atLeftSideUp");
    bool arrived = false;
    public int id;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(arrived){
            animator.SetTrigger(atRightSideUpHash);
            animator.SetTrigger(atLeftSideUpHash);
            arrived = false;
        }
        if (UnityEngine.Random.Range(1, 100) > 98)
        {
            player.Attack();
        }
        if (UnityEngine.Random.Range(0, 1000) < 1)
        {
            animator.SetInteger("platform",-1);
        }
    }

    public bool MoveToPosition(float z)
    {
        if (Math.Abs(player.transform.position.z - z) < 0.5f)
        {
            player.RightLeftJump(new Vector2(0, 0));  
            arrived = true;
            return true;
        }
        arrived = false;
        if (player.transform.position.z < z)
        {
            player.RightLeftJump(new Vector2(1, 0));
        }
        if (player.transform.position.z > z)
        {
            player.RightLeftJump(new Vector2(-1, 0));
        }
        return false;
    }


    public void MoveTo(float y){
        player.RightLeftJump(new Vector2(y,0));
    }

    public void JumpTo(float y){
        player.RightLeftJump(new Vector2(y,1));
    }

    public void chooseBehaviour(){
        Debug.Log("Choosing Behaviour");
        //Choose player to follow
        (int[] platforms,bool[] died) = gameManager.getGameState();
        List<int> notDeadPlayers = new List<int>{};
        for(int i = 0 ; i < 4;++i){
            if(i==id || died[i]) continue;
            notDeadPlayers.Add(i);
        }
        int randomChoice = UnityEngine.Random.Range(0,notDeadPlayers.Count);
        target = gameManager.getPlayer(randomChoice);
        animator.SetInteger("platform",target.getPlatform());
        Debug.Log(target.getPlatform().ToString());
    }
}

