using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrap : FSM
{
    private enum State
    {
        START,
        HOVERING,
        FALLING,
        OPENING,
        DONE,
    }
    private TrapControl trap;
    private int owner;
    private State state;
    public SetTrap(int trapOwner)
    {
        trap = (TrapControl) GameObject.FindGameObjectsWithTag("Trap")[0].GetComponent(typeof(TrapControl));
        owner = trapOwner;
    }

    // Update is called once per frame
    override public bool update()
    {
        switch (state)
        {
            case State.START:
                if (trap.movementCompleted())
                {
                    state = State.HOVERING;
                    trap.moveAbovePlayerTile(owner);
                }
                break;
            case State.HOVERING:
                if (trap.movementCompleted())
                {
                    state = State.FALLING;
                    trap.moveToPlayerTile(owner);
                }
                break;
            case State.FALLING:
                if (trap.movementCompleted())
                {
                    state = State.OPENING;
                }
                break;
            case State.OPENING:
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
