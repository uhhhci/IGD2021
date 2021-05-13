using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public Tile startTile;
    
    // TODO inventory
    // TODO credits
    // TODO more stats for achievements
    // TODO golden bricks
    // TODO true party person status flag

    private int distanceWalked = 0; // TODO: use this for the "most distance walked" achievement
    private int actionPoints = 0;
    private Tile tile;

    public Tile currentTile() {
        return  tile;
    }

    public void moveTo(Tile newTile) {
        // separate from walk so it can be used to shuffle 
        // the player positions (master hand event)
        tile = newTile;
    }

    public void walk() {
        actionPoints--;
        distanceWalked++;
        Debug.Log("walking, remaining APs: " + actionPoints);
    }

    public void setActionPoints(int availablePoints) {
        actionPoints = availablePoints;
    }

    public int actionPointsLeft() {
        return actionPoints;
    }

    // Start is called before the first frame update
    void Start()
    {
        tile = startTile;
    }
}
