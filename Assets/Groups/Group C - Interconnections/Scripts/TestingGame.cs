
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This class extends the MiniGame abstract class
 * Implementing the 3 required methods: getDisplayName, getSceneName, getMiniGameType
 * 
 */
public class TestingGame : MiniGame
{

    public GameObject myPlayer;
    public GameObject secondPlayer;
    

    public override string getDisplayName(){
        return "My Awesome Game";
    }
    public override string getSceneName(){
        return "MyAwesomeGameScene";
    }

    public override MiniGameType getMiniGameType()
    {
        return MiniGameType.freeForAll;
    }

    private void Start()
    {
        //Create list of player inputs from the players in the scene
        var playerInputs = new List<PlayerInput> { myPlayer.GetComponent<PlayerInput>(), secondPlayer.GetComponent<PlayerInput>() };

        //This assigns the player input in the order they were given in the array
        InputManager.Instance.AssignPlayerInput(playerInputs);
        
    }

    void Update()
    {
        //If your game has already ended you can call the MiniGameFinished method
        bool myGameEndingCondition = false;
        if (myGameEndingCondition == true)
        {
            //Create array of positions with player ids, this also works in case there are multiple players in one position
            int[] first = { 0 };
            int[] second = { 1 };
            int[] third = { 2 };
            int[] fourth = { 3 };

            //Note this is still work in progress, but ideally you will use it like this
            MiniGameFinished(firstPlace: first, secondPlace: second, thirdPlace: third, fourthPlace: fourth);
        }

    }
}