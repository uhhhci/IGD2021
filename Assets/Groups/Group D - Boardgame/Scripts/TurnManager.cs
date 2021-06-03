using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    public enum Directions {
        LEFT,
        RIGHT, 
        UP,
        DOWN,
    }
    // number of rounds until the game ends
    public int numberOfRounds = 10;

    // the four player controllers (used to animate the player figures)
    public List<BoardgameController> players = new List<BoardgameController>(4);
    // their associated data
    public List<PlayerData> playerData = new List<PlayerData>(4);

    public List<ItemD> allItems;

    // mapping from item enum values to the respective item object
    private Dictionary<ItemD.Type, ItemD> itemDataBase;

    // stores the credits, golden bricks, and items of each player
    public List<PlayerDisplay> playerBelongings = new List<PlayerDisplay>(4);
    
    public GoldenBrickManager brickManager;

    public Transform playerMarkerTransform;

    public CameraMovement camera;

    public HUD hud;
    public InteractionMenu interactions;

    public float playerMarkerHoverDistance = 3.0f;
    public float playerMarkerBobbleSpeed = 2.0f;
    public float playerMarkerBobbleAmplitude = 0.5f;

    private int activePlayer = 0;
    private int round = 1;
    private int actionPoints = 0;

    private enum TurnState {MOVING_CAM_TO_DIE, ROLLING_DIE, MOVING_CAM_TO_PLAYER, ACCEPTING_INPUT, EXECUTING_ACTION, APPLYING_TILE_EFFECT, TURN_ENDED,};
    private TurnState currentState;

    // currently executed FSM
    // FSMs are control various animations and are executed in some turn states
    private FSM currentActionFSM = null;

    // Start is called before the first frame update
    void Start() {

        // fill/create the item lookup table
        itemDataBase = new Dictionary<ItemD.Type, ItemD>();

        foreach (ItemD item in allItems) {
            itemDataBase[item.type] = item;
        }        

        moveToDie();

         // TODO: DEBUG ONLY, REMOVE THIS WHEN THE SHOP IS IMPLEMENTED
        playerBelongings[0].addItem(itemDataBase[ItemD.Type.CREDIT_THIEF]);
        playerBelongings[0].addItem(itemDataBase[ItemD.Type.TRAP]);
    }

    // Update is called once per frame
    void Update()
    {

        if (currentState == TurnState.MOVING_CAM_TO_DIE && camera.movementCompleted()) {
            rollDie();
        }
        else if (currentState == TurnState.ROLLING_DIE && DieScript.isDone() && DieScript2.isDone())
        {
            actionPoints = DieScript.rollResult + DieScript2.rollResult;
            currentState = TurnState.MOVING_CAM_TO_PLAYER;
            camera.moveToPlayer(activePlayer);
        }
        else if (currentState == TurnState.MOVING_CAM_TO_PLAYER && camera.movementCompleted()) {
            startNewTurn();
        }
        else if (currentState == TurnState.ACCEPTING_INPUT && actionPoints <= 0) {
            applyTileEffect();
        }
        else if (currentState == TurnState.EXECUTING_ACTION && currentActionFSM.update()) {
            currentActionFSM = null;
            
            if (actionPoints <= 0) {
                // turn is over!
                applyTileEffect();
            }
            else {
                // await next input/action
                currentState = TurnState.ACCEPTING_INPUT;
            }
        }
        else if (currentState == TurnState.APPLYING_TILE_EFFECT && currentActionFSM.update()) {
            currentState = TurnState.TURN_ENDED;
        }
        else if (currentState == TurnState.TURN_ENDED) {
            finishTurn();
        }
        
        foreach (PlayerAction action in interactions.actions) {        
            if (currentState == TurnState.ACCEPTING_INPUT && actionPoints > 0) {
                action.updateStatus(actionIsActive(action), canAfford(action));
            }
            else {
                action.updateStatus(false, false);
            }
        }

        updateHUD();
    }

    /// returns whether the given action is "in principle" currently available for the player,
    /// i.e. whether the action could be used in this state independently of the action's costs (AP + credits)
    private bool actionIsActive(PlayerAction action) {
        switch (action.type) {
            case PlayerAction.Type.END_TURN:
                return true;
            case PlayerAction.Type.BUY_GOLDEN_BRICK:
                return playerData[activePlayer].currentTile().hasGoldenBrick();
            case PlayerAction.Type.ITEM_CREDIT_THIEF:
                return playerBelongings[activePlayer].hasItem(itemDataBase[ItemD.Type.CREDIT_THIEF]);
            case PlayerAction.Type.SET_TRAP:
                return playerBelongings[activePlayer].hasItem(itemDataBase[ItemD.Type.TRAP]);
        }
        return false;
    }

    /// returns whether the player can afford the given action (i.e. whether they have enough AP and credits)
    private bool canAfford(PlayerAction action) {
        return action.requiredAP <= actionPoints && action.requiredCredits <= playerBelongings[activePlayer].creditAmount();
    }

    private void finishAction() {
        if (actionPoints <= 0) {
            // turn is over!
            applyTileEffect();
            return;
        }

        currentState = TurnState.ACCEPTING_INPUT;
    }

    private void applyTileEffect() {
        currentState = TurnState.APPLYING_TILE_EFFECT;
        
        switch(playerData[activePlayer].currentTile().type) {
            case Tile.TileType.GAIN_COINS:
                currentActionFSM = new TileGainCoins(playerBelongings[activePlayer]);
                break;
            case Tile.TileType.LOSE_COINS:
                currentActionFSM = new TileLoseCoins(playerBelongings[activePlayer]);
                break;
            case Tile.TileType.RANDOM_EVENT:
                currentActionFSM = new TileRandomEvent();
                Debug.Log("Standing on a purple tile");
                break;
            case Tile.TileType.MASTER_HAND:
                currentActionFSM = new TileMasterHand();
                break;
            case Tile.TileType.START:
                // do nothing -> skip to next state
                currentState = TurnState.TURN_ENDED;
                break;
        }
    }

    private void finishTurn() {
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
            moveToDie();
        }
    }

    private void moveToDie() {
        camera.moveToDice();
        currentState = TurnState.MOVING_CAM_TO_DIE;
    }

    private void rollDie() {
        currentState = TurnState.ROLLING_DIE;
        DieScript.rollDie();
        DieScript2.rollDie();
    }

    private void endGame() {
        // pass some parameters to the next scene
        for (int i = 0; i < 4; i++) {
            EndScreen.playerStats[i] = new EndScreen.PlayerStats(i, playerBelongings[i].goldenBricks(), playerBelongings[i].creditAmount());
        }

        SceneManager.LoadScene("Groups/Group D - Boardgame/Scenes/EndScreen");
    }

    private void startNewTurn() {
        currentState = TurnState.ACCEPTING_INPUT;
    }

    private void updateHUD() {
        hud.updateRound(round);

        if (interactions.anActionIsSelected()) { // display the costs of the selected action 
            hud.updateActionPoints(actionPoints, interactions.getSelectedActionAPCost());
            playerBelongings[activePlayer].setDisplayedCreditCosts(interactions.getSelectedActionCreditCost());
        } 
        else {
            hud.updateActionPoints(actionPoints);
            playerBelongings[activePlayer].setDisplayedCreditCosts(0);
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
        playerBelongings.ForEach((belongings) => {
            belongings.addCreditAmount((int) Random.Range(0f, 3.99f));
        });
    }

    /// executes the given action
    private void executeAction(PlayerAction action) {
        if (action == null || !action.isUsable()) {
            return;
        }

        switch (action.type) {
            case PlayerAction.Type.END_TURN:
                actionPoints = 0;
                break;
            case PlayerAction.Type.BUY_GOLDEN_BRICK:
                playerBelongings[activePlayer].addGoldenBrick();
                players[activePlayer].PlayPickupSound();
                brickManager.relocate();
                break;
            case PlayerAction.Type.ITEM_CREDIT_THIEF:
                // item is "used" -> remove it from the inventory
                playerBelongings[activePlayer].removeItem(itemDataBase[ItemD.Type.CREDIT_THIEF]);
                currentState = TurnState.EXECUTING_ACTION;
                currentActionFSM = new ItemCreditThief(camera, activePlayer, playerBelongings);
                break;
            case PlayerAction.Type.SET_TRAP:
                //TODO: trap visuals
                playerData[activePlayer].currentTile().setTrap(true,activePlayer);
                //TODO: add soundeffect
                playerBelongings[activePlayer].removeItem(itemDataBase[ItemD.Type.TRAP]);
                break;
        }

        actionPoints -= action.requiredAP;
        playerBelongings[activePlayer].addCreditAmount(-action.requiredCredits); // TODO: wait until animation is complete
    }

    public void reactToMove(Directions direction, int playerNumber)
    {
        if (currentState != TurnState.ACCEPTING_INPUT || playerNumber != activePlayer) {
            return;
        }
       
        Tile nextTile = null;

        switch (direction) {
            case Directions.LEFT:
                nextTile = playerData[activePlayer].currentTile().left;
                break;
            case Directions.RIGHT:
                nextTile = playerData[activePlayer].currentTile().right;
                break;
            case Directions.UP:
                nextTile = playerData[activePlayer].currentTile().up;
                break;
             case Directions.DOWN:
                nextTile = playerData[activePlayer].currentTile().down;
                break;
        }

        if (nextTile == null) {
            // there is no neighboring tile in this direction
            return;
        }

        currentState = TurnState.EXECUTING_ACTION;
        actionPoints--;
        currentActionFSM = new Walking(players[activePlayer], playerData[activePlayer], nextTile);
    }

    public void reactToNorth(int playerNumber)
    {
        if (currentState != TurnState.ACCEPTING_INPUT || playerNumber != activePlayer) {
            return;
        }
       
        interactions.nextAction();
    }

    public void reactToEast(int playerNumber)
    {
        if (currentState != TurnState.ACCEPTING_INPUT || playerNumber != activePlayer) {
            return;
        }
       
        executeAction(interactions.getSelectedAction());
    }

    public void reactToSouth(int playerNumber)
    {
        if (currentState != TurnState.ACCEPTING_INPUT || playerNumber != activePlayer) {
            return;
        }
       
        interactions.previousAction();
    }
}
