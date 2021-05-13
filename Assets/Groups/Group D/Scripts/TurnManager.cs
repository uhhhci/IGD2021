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
 
    public Transform playerMarkerTransform;
 
    public Text actionPointDisplay;

    public float playerMarkerHoverDistance = 3.0f;
    public float playerMarkerBobbleSpeed = 2.0f;
    public float playerMarkerBobbleAmplitude = 0.5f;

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
        if (playerData[activePlayer].actionPointsLeft() == 0 && playerData[activePlayer].isIdle()) {
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
            loadMinigame();
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

        float offset = Mathf.Sin(Time.timeSinceLevelLoad * playerMarkerBobbleSpeed);
        offset *= playerMarkerBobbleAmplitude;
        offset += playerMarkerHoverDistance;

        Vector3 markerPos = playerData[activePlayer].transform.position;
        markerPos.y += offset;
        playerMarkerTransform.position = markerPos;
    }

    private void loadMinigame() {
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
    }
}
