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
    private PlayerData ownerData;
    private Transform ownerTransform;
    private State state;
    
    public SetTrap(PlayerData data, Transform transform, GameObject trapObject)
    {
        trap = (TrapControl) trapObject.GetComponent(typeof(TrapControl));
        ownerData = data;
        ownerTransform = transform;
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
                    trap.moveAbovePlayerTile(ownerData);
                }
                break;
            case State.HOVERING:
                if (trap.movementCompleted())
                {
                    state = State.FALLING;
                    trap.moveToPlayerTile(ownerData);
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
                    trap.playDropAudio();
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
