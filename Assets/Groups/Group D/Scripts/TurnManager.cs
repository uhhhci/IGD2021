using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    // number of rounds until the game ends
    public int numberOfRounds = 10;

    // the four player controllers
    public List<BoardgameController> players = new List<BoardgameController>(4);
    // their associated date
    public List<PlayerData> playerData = new List<PlayerData>(4);
 
    public Transform playerMarkerTransform;
 
    public HUD hud;
    public InteractionMenu interactions;

    public float playerMarkerHoverDistance = 3.0f;
    public float playerMarkerBobbleSpeed = 2.0f;
    public float playerMarkerBobbleAmplitude = 0.5f;

    private int activePlayer = 0;
    private int round = 0;

    private enum TurnState {ROLLING_DIE, MOVING,};
    private TurnState currentState;

    // Start is called before the first frame update
    void Start() {
        players.ForEach((p) => {p.SetInputEnabled(false);});
        interactions.setActivePlayer(playerData[activePlayer]);
        rollDie();
        //startNewTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == TurnState.ROLLING_DIE && DieScript.isDone())
        {
            playerData[activePlayer].setActionPoints(DieScript.rollResult);
            currentState =  TurnState.MOVING;
            
            playerData[activePlayer].setIdle(true);
            startNewTurn();
        }
        if (currentState == TurnState.MOVING && playerData[activePlayer].actionPointsLeft() <= 0 && playerData[activePlayer].isIdle()) {
            endTurn();
        }
        
        updateHUD();
    }

    public void endTurn() {
        // lock controls of the previous player 
        players[activePlayer].SetInputEnabled(false);

        switch(playerData[activePlayer].currentTile().type) {
            case Tile.TileType.GAIN_COINS:
                Debug.Log("Standing on a blue tile");
                break;
            case Tile.TileType.LOSE_COINS:
                Debug.Log("Standing on a red tile");
                break;
            case Tile.TileType.RANDOM_EVENT:
                Debug.Log("Standing on a purple tile");
                break;
            case Tile.TileType.MASTER_HAND:
                Debug.Log("Standing on a orange tile");
                break;
            case Tile.TileType.START:
                Debug.Log("Standing on the start tile");
                break;
        }

        // next player
        activePlayer++;

        if (activePlayer == 4) {
            loadMinigame();
            activePlayer = 0;
            round++;
        }

        if (round >= numberOfRounds) {
            endGame();
        } 
        else {
            rollDie();
            interactions.setActivePlayer(playerData[activePlayer]);
        }
    }

    private void rollDie() {
        currentState =  TurnState.ROLLING_DIE;
        playerData[activePlayer].setIdle(false);
        DieScript.rollDie();
    }

    private void endGame() {
        // pass some parameters to the next scene
        for (int i = 0; i < 4; i++) {
            EndScreen.playerStats[i] = new EndScreen.PlayerStats(i, playerData[i].goldenBricks(), playerData[i].creditAmount());
        }

        SceneManager.LoadScene("Groups/Group D/Scenes/EndScreen");
    }

    private void startNewTurn() {
        // unlock controls of the previous player 
        players[activePlayer].SetInputEnabled(true);
    }

    private void updateHUD() {
        hud.updateActionPoints(playerData[activePlayer].actionPointsLeft());
        hud.updateRound(round);

        for (int i = 0; i < 4; i++) {
            hud.updateCredits(i, playerData[i].creditAmount());
            hud.updateBricks(i, playerData[i].goldenBricks());
        }

        // marker other active player
        float offset = Mathf.Sin(Time.timeSinceLevelLoad * playerMarkerBobbleSpeed);
        offset *= playerMarkerBobbleAmplitude;
        offset += playerMarkerHoverDistance;

        Vector3 markerPos = playerData[activePlayer].transform.position;
        markerPos.y += offset;
        playerMarkerTransform.position = markerPos;
    }

    private void loadMinigame() {
        // TODO: this is a dummy implementation
        int team1 = 0;
        int team2 = 0;

        playerData.ForEach((data) => {
            Tile.TileType t = data.currentTile().type;

            if (t == Tile.TileType.GAIN_COINS || t == Tile.TileType.RANDOM_EVENT) {
                team1++;
            }
            else {
                team2++;
            }
        });

        if (team1 == 0 || team2 == 0) {
            Debug.Log("Loading a free-for-all minigame.");
        }
        else if (team1 == team2) {
            Debug.Log("Loading a 2v2 minigame.");
        } 
        else {
            Debug.Log("Loading a 1v3 minigame.");
        }

        // add a random amount of credits
        playerData.ForEach((data) => {
            data.addCreditAmount((int) Random.Range(0f, 3.99f));
        });
    }
}
