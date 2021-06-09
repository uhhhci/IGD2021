﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTrap : FSM
{
    private enum State
    {
        START,
        RISING,
        HOVERING,
        DONE,
    }
    private TrapControl trap;
    //private int owner;
    private State state;
    private int player;
    public RemoveTrap(int triggeringPlayer)
    {
        trap = (TrapControl) GameObject.FindGameObjectsWithTag("Trap")[0].GetComponent(typeof(TrapControl));
        player = triggeringPlayer;
    }

    // Update is called once per frame
    override public bool update()
    {
        switch (state)
        {
            case State.START:
                if (trap.movementCompleted())
                {
                    state = State.RISING;
                    trap.moveAbovePlayerTile(player);
                    trap.playTriggerAudio();
                }
                break;
            case State.RISING:
                if (trap.movementCompleted())
                {
                    trap.returnToLoiterPoint();
                    state = State.HOVERING;
                }
                break;
            case State.HOVERING:
                if (trap.movementCompleted())
                {
                    state = State.DONE;
                }
                break;
            case State.DONE:
                if (trap.movementCompleted())
                {
                    return true;
                }
                break;
        }
        return false;
    }
}
