using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreditThief : FSM
{
    private enum State {
        MOVE_CAM_TO_TARGET, // camera moves to target player
        INTRO, // Spawn thief, thief flies to target player
        STEALING, // steal some coins
        MOVE_TO_PLAYER, // move thief + camera to the player who used the item
        GIVING, // give stolen coins to player
        OUTRO, // thief flies away
    }

    private State state;
    private CameraMovement cam;
    private PlayerDisplay targetStuff;
    private PlayerDisplay playerStuff;
    private int player;
    private int target;
    private int loot;
    private CreditThiefControl thief;

    public ItemCreditThief(CameraMovement camera, int usingPlayer, List<PlayerDisplay> playerBelongings) {
        cam = camera;
        player = usingPlayer;
        playerStuff = playerBelongings[player];
       
        thief = (CreditThiefControl) GameObject.FindGameObjectsWithTag("ItemCreditThief")[0].GetComponent(typeof(CreditThiefControl));

        // loot = 20% of the richest players credits rounded down; if the target player has at least 1 coin 
        // and this formula results in loot == 0, set loot = 1
        int maxCredits = -1;
        for (int i = 0; i < 4; i++) {
            if (i == player) {
                continue;
            }
            if (playerBelongings[i].creditAmount() > maxCredits) {
                maxCredits = playerBelongings[i].creditAmount();
                target = i;
            }
        }   

        targetStuff = playerBelongings[target];
      
        loot = (int) (0.2 * maxCredits);

        if (loot == 0 && targetStuff.creditAmount() > 0) {
            loot = 1;
        }

        // start state:
        state = State.MOVE_CAM_TO_TARGET;
        cam.moveToPlayer(target);
    }

    override public bool update() {
        switch (state)
        {
            case State.MOVE_CAM_TO_TARGET:
                if (cam.movementCompleted()) {
                    state = State.INTRO;
                    thief.moveToPlayer(target);
                }
                break;
            case State.INTRO:
                if (thief.movementCompleted()) {
                    state = State.STEALING;
                    targetStuff.addCreditAmount(-loot);
                }
                break;
            case State.STEALING:
                if (targetStuff.animationsAreDone()) {
                    state = State.MOVE_TO_PLAYER;
                    cam.followItemThief();
                    thief.moveToPlayer(player);
                    thief.playStealAudio(); //audioclip for stealing
                }
                break;
            case State.MOVE_TO_PLAYER:
                if (thief.movementCompleted()) {
                    state = State.GIVING;
                    cam.moveToPlayer(player);
                    playerStuff.addCreditAmount(loot);
                }
                break;
            case State.GIVING:
                if (playerStuff.animationsAreDone() && cam.movementCompleted()) {
                    state = State.OUTRO;
                    thief.returnToLoiterPoint();
                }
                break;
            case State.OUTRO:
                if (thief.movementCompleted()) {
                    return true; // final state
                }
                break;
        }
        return false;
    }
}
