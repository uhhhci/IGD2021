using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRandomGiveItem : FSM
{
    public TileRandomGiveItem(PlayerDisplay playersStuff, ItemD.Type selectedItem) {
        playersStuff.addItem(selectedItem);
    }

    override public bool update() {
        // TODO: sounds would be nice
        return true;
    }
}
