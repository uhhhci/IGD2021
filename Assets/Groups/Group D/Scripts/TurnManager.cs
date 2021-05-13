using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public int initialActionPoints; 

    // the four player controllers
    public List<BoardgameController> players = new List<BoardgameController>(4);
    // their associated date
    public List<PlayerData> playerData = new List<PlayerData>(4);
 
 
    public Text actionPointDisplay;


    private int activePlayer = 0;
    private int round = 0;


    // Start is called before the first frame update
    void Start() {
        players.ForEach((p) => {p.SetInputEnabled(false);});

        startNewTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerData[activePlayer].actionPointsLeft() == 0) {
            nextTurn();
        }
        
        updateHUD();
    }

    public void nextTurn() {
        // lock controls of the previous player 
        players[activePlayer].SetInputEnabled(false);

        // next player
        activePlayer++;

        if (activePlayer == 4) {
            Debug.Log("round completed");
            // TODO: load a minigame

            activePlayer = 0;
            round++;
        }

        startNewTurn();
    }

    private void startNewTurn() {
        // unlock controls of the previous player 
        players[activePlayer].SetInputEnabled(true);

        // TODO: replace with a dice roll/random number
        playerData[activePlayer].setActionPoints(initialActionPoints);
    }

    private void updateHUD() {
        actionPointDisplay.text = "Round: " + round + " Player: " + activePlayer.ToString() + " APs left: " + playerData[activePlayer].actionPointsLeft().ToString();
    }
}
