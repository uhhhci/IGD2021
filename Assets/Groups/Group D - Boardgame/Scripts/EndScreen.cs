using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public class PlayerStats : IComparable<PlayerStats> {
        public PlayerStats(int playerNumber, int bricks, int credits) {
            this.credits = credits;
            this.bricks = bricks;
            this.playerNumber = playerNumber;
        }

        public int credits { get; }
        public int bricks { get; }
        public int playerNumber { get; }

        public int CompareTo(PlayerStats other) {
            if (this.bricks < other.bricks || (this.bricks == other.bricks && this.credits < other.credits) ) {
                return -1;
            }
            if (this.bricks > other.bricks || (this.bricks == other.bricks && this.credits > other.credits)) {
                return +1;
            }
            return 0;
        }
    }

    // pass golden brick and credits counts
    // first player must be the first element, 2nd one in the 2nd, etc.
    // must contain 4 elements
    // set by the TurnManager from the Boardgame scene before this the EndScreen scene is loaded
    public static PlayerStats[] playerStats = new PlayerStats[4];

    // number of seconds before the scene (and game) ends
    public float endDelay = 5f; 

    // UI elements
    public Text player1PlacementDisplay;
    public Text player2PlacementDisplay;
    public Text player3PlacementDisplay;
    public Text player4PlacementDisplay;
    public Text player1BrickDisplay;
    public Text player2BrickDisplay;
    public Text player3BrickDisplay;
    public Text player4BrickDisplay;
    public Text player1CreditDisplay;
    public Text player2CreditDisplay;
    public Text player3CreditDisplay;
    public Text player4CreditDisplay;

    // Start is called before the first frame update
    void Start()
    {
        if (playerStats[0] != null) {
            fillInRealData();
        }
        else {
            // TODO: for debug and demonstration only
            // (so that you don't have to load this scene from the Boardgame scene each time)
            fillInDummyData();
        }
       

        Invoke("EndGame", endDelay);
    }

    private void fillInRealData() {
        player1CreditDisplay.text = playerStats[0].credits.ToString();
        player2CreditDisplay.text = playerStats[1].credits.ToString();
        player3CreditDisplay.text = playerStats[2].credits.ToString();
        player4CreditDisplay.text = playerStats[3].credits.ToString();

        player1BrickDisplay.text = playerStats[0].bricks.ToString();
        player2BrickDisplay.text = playerStats[1].bricks.ToString();
        player3BrickDisplay.text = playerStats[2].bricks.ToString();
        player4BrickDisplay.text = playerStats[3].bricks.ToString();

        Array.Sort(playerStats);

        int lastBrickCount = playerStats[3].bricks;
        int lastCreditCount = playerStats[3].credits;
        int lastRank = 1;

        for (int i = 3; i >= 0; i--) {
            // check, whether there is a tie between this player and the last one 
            if (lastBrickCount > playerStats[i].bricks) {
                // no tie
                lastRank++;
            }
            else if (lastCreditCount > playerStats[i].credits) {
                // no tie
                lastRank++;
            }
            // else: tie between the players

            lastBrickCount = playerStats[i].bricks;
            lastCreditCount = playerStats[i].credits;

            string rank = lastRank.ToString();

            switch (playerStats[i].playerNumber) {
                case 0:
                   player1PlacementDisplay.text = rank; 
                   break;
                case 1:
                   player2PlacementDisplay.text = rank; 
                   break;
                case 2:
                   player3PlacementDisplay.text = rank; 
                   break;
                case 3:
                   player4PlacementDisplay.text = rank; 
                   break;
            }
        }
    }

    private void fillInDummyData() {
        player1CreditDisplay.text = "10";
        player2CreditDisplay.text = "2";
        player3CreditDisplay.text = "0";
        player4CreditDisplay.text = "123";

        player1BrickDisplay.text = "0";
        player2BrickDisplay.text = "3";
        player3BrickDisplay.text = "12";
        player4BrickDisplay.text = "1";

        player1PlacementDisplay.text = "4";
        player2PlacementDisplay.text = "2";
        player3PlacementDisplay.text = "1";
        player4PlacementDisplay.text = "3";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndGame() {
        // TODO: return to main menu
    }
}
