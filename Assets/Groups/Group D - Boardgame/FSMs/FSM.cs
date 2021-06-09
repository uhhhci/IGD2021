using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// a final state machine
public abstract class FSM 
{
    // call this method to update the FSM
    // returns true if and only if the FSM is in a final state
    public abstract bool update();
}
