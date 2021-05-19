using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// place for stats and properties of the player
// e.g. distance walked, current amounts of credits and golden bricks,
// tile the player is currently on, etc.
public class PlayerData : MonoBehaviour
{
    public Tile startTile;
    
    // TODO inventory
    // TODO more stats for achievements
    // TODO golden bricks
    // TODO true party person status flag

    private int distanceWalked = 0; // TODO: use this for the "most distance walked" achievement
    private int actionPoints = 0;
    private Tile tile;
    private bool idle = true;
    private int credits = 0;
    private int bricks = 0;

    public bool isIdle() {
        return idle;
    }

    public void setIdle(bool value) {
        idle = value;
    }

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
    }

    public void setActionPoints(int availablePoints) {
        actionPoints = availablePoints;
    }

    public void addActionPoints(int amount) {
        actionPoints += amount;
    }

    public int actionPointsLeft() {
        return actionPoints;
    }

    public int creditAmount() {
        return credits;
    }

    public void addCreditAmount(int amount) {
        // use negative amount for subtraction
        credits += amount;
    }

    public int goldenBricks() {
        return bricks;
    }

    public void addGoldenBrick() {
        bricks++;
    }

    // Start is called before the first frame update
    void Start()
    {
        tile = startTile;
    }
}
