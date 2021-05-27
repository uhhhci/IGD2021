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

    private enum TurnState {MOVING_CAM_TO_DIE, ROLLING_DIE, MOVING_CAM_TO_PLAYER, ACCEPTING_INPUT, MOVING, APPLYING_TILE_EFFECT, TURN_ENDED,};
    private TurnState currentState;

    // all of the following variables are only used by the tile effect code
    // TODO: refactor the tile effect code
    // TODO: the "gaining/losing credits animations" (+ sounds when added) must be reusable (buying things, after minigames, etc.) 
    private enum TileEffect {GAINING_CREDITS, LOSING_CREDITS, NONE};
    private TileEffect currentTileEffect = TileEffect.NONE;


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
        else if (currentState == TurnState.MOVING && players[activePlayer].animationDone()) {
            finishMovement();
        }
        else if (currentState == TurnState.APPLYING_TILE_EFFECT) {
            animateTileEffect();
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
        }
        return false;
    }

    /// returns whether the player can afford the given action (i.e. whether they have enough AP and credits)
    private bool canAfford(PlayerAction action) {
        return action.requiredAP <= actionPoints && action.requiredCredits <= playerBelongings[activePlayer].creditAmount();
    }

    private void finishMovement() {
        if (actionPoints <= 0) {
            // turn is over!
            applyTileEffect();
            return;
        }

        currentState = TurnState.ACCEPTING_INPUT;
    }

    private void animateTileEffect() {
        switch (currentTileEffect) {
            case TileEffect.GAINING_CREDITS:
                if (playerBelongings[activePlayer].animationsAreDone()) {
                    currentState = TurnState.TURN_ENDED;
                }
                break;
            case TileEffect.LOSING_CREDITS:
                if (playerBelongings[activePlayer].animationsAreDone()) {
                    currentState = TurnState.TURN_ENDED;
                }
                break;
            default:
                currentState = TurnState.TURN_ENDED;
                break;
        }
    }

    private void applyTileEffect() {
        currentState = TurnState.APPLYING_TILE_EFFECT;
        currentTileEffect = TileEffect.NONE;

        switch(playerData[activePlayer].currentTile().type) {
            case Tile.TileType.GAIN_COINS:
                currentTileEffect = TileEffect.GAINING_CREDITS;
                playerBelongings[activePlayer].addCreditAmount(2);
                break;
            case Tile.TileType.LOSE_COINS:
                currentTileEffect = TileEffect.LOSING_CREDITS;
                playerBelongings[activePlayer].addCreditAmount(Mathf.Max(-2, -playerBelongings[activePlayer].creditAmount()));
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
        } 
        else {
            hud.updateActionPoints(actionPoints);
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
                brickManager.relocate();
                break;
            case PlayerAction.Type.ITEM_CREDIT_THIEF:
                // TODO: animate the actual effect, wait until the animation (including the bobbing of credits when losing/receiving them) is completed
                // drone flies to the player with the most credits, 
                // "steals" a few credits (e.g. X%), flies to the player who used the item,
                // gives him/her the stolen credits, then flies away


                int maxCredits = -1;
                int target = -1;
                for (int i = 0; i < 4; i++) {
                    if (i == activePlayer) {
                        continue;
                    }
                    if (playerBelongings[i].creditAmount() > maxCredits) {
                        maxCredits = playerBelongings[i].creditAmount();
                        target = i;
                    }
                }   

                int loot = (int) (0.2 * maxCredits);
                playerBelongings[target].addCreditAmount(-loot);
                playerBelongings[activePlayer].addCreditAmount(loot);


                // item is "used" -> remove it from the inventory
                playerBelongings[activePlayer].removeItem(itemDataBase[ItemD.Type.CREDIT_THIEF]);
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

        currentState = currentState = TurnState.MOVING;
        actionPoints--;

        playerData[activePlayer].walk();
        playerData[activePlayer].moveTo(nextTile);

        players[activePlayer].MoveToTile(nextTile);
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
