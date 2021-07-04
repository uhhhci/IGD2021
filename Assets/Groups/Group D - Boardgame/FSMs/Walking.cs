using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : FSM
{
    private BoardgameController activeController;
    private Tile target;
    private double time = 0.0;

    public Walking(BoardgameController controller, PlayerData data, Tile nextTile) {
        activeController = controller;
        target = nextTile;

        // start state:
        data.walk();
        data.moveTo(target);
        activeController.MoveToTile(target);
    }

    override public bool update() {
        time += Time.deltaTime;

        if (time > 2.0f) {
            // rare bug: movement does not finish correctly. The cause could not be identified over several weeks.
            Debug.Log("Movement bug occurred!");
            // attempted workaround: do the movement again
            time = 0.0f;
            activeController.MoveToTile(target);


        }

        return activeController.animationDone();
    }
}
