using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGainCoins : FSM
{
    private PlayerDisplay playerBelongings;

    public TileGainCoins(PlayerDisplay belongings) {
        playerBelongings = belongings;
        
        // start state:
        playerBelongings.addCreditAmount(2);
    }

    override public bool update() {
        return playerBelongings.animationsAreDone();
    }
}
