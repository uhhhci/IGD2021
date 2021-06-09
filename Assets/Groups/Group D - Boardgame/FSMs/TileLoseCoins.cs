using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLoseCoins : FSM
{
    private PlayerDisplay playerBelongings;

    public TileLoseCoins(PlayerDisplay belongings) {
        playerBelongings = belongings;
        
        // start state:
        playerBelongings.addCreditAmount(Mathf.Max(-2, -playerBelongings.creditAmount()));
    }

    override public bool update() {
        return playerBelongings.animationsAreDone();
    }
}
