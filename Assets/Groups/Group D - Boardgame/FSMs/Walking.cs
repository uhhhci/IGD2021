using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : FSM
{
    private BoardgameController activeController;

    public Walking(BoardgameController controller, PlayerData data, Tile nextTile) {
        activeController = controller;
        
        // start state:
        data.walk();
        data.moveTo(nextTile);
        activeController.MoveToTile(nextTile);
    }

    override public bool update() {
        return activeController.animationDone();
    }
}
