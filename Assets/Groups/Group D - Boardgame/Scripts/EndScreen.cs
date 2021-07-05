using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        fillInRealData();

        Invoke("EndGame", endDelay);
    }

    private void fillInRealData() {
        for (int i = 0; i < 4; i++) {
            Debug.Log("playerStats[" + i.ToString() + "] = " + playerStats[i].bricks.ToString() + " bricks and " + playerStats[i].credits.ToString() + " credits");
        }

        Array.Sort(playerStats);

        for (int i = 0; i < 4; i++) {
            Debug.Log("playerStats[" + i.ToString() + "] = " + playerStats[i].bricks.ToString() + " bricks and " + playerStats[i].credits.ToString() + " credits");
        }

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

            Debug.Log("Player " + playerStats[i].playerNumber.ToString() + " is on place " + rank + " with " + lastBrickCount.ToString() + " bricks and " + lastCreditCount.ToString() + " credits");
            
            switch (playerStats[i].playerNumber) {
                case 0:
                   player1PlacementDisplay.text = rank; 
                   player1CreditDisplay.text = lastCreditCount.ToString();
                   player1BrickDisplay.text = lastBrickCount.ToString();
                   break;
                case 1:
                   player2PlacementDisplay.text = rank; 
                   player2CreditDisplay.text = lastCreditCount.ToString();
                   player2BrickDisplay.text = lastBrickCount.ToString();
                   break;
                case 2:
                   player3PlacementDisplay.text = rank; 
                   player3CreditDisplay.text = lastCreditCount.ToString();
                   player3BrickDisplay.text = lastBrickCount.ToString();
                   break;
                case 3:
                   player4PlacementDisplay.text = rank; 
                   player4CreditDisplay.text = lastCreditCount.ToString();
                   player4BrickDisplay.text = lastBrickCount.ToString();
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
        // return to the character selection
        SceneManager.LoadScene("Customization");
    }
}
