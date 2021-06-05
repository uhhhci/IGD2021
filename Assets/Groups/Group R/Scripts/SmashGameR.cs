using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This class handles the initialization of our Lego Smash game
 */
public class SmashGameR : MiniGame
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public override string getDisplayName()
    {
        return "LEGO Smash";
    }
    public override string getSceneName()
    {
        return "Scene1Thilo";
    }

    public override MiniGameType getMiniGameType()
    {
        return MiniGameType.freeForAll;
    }

    private void Start()
    {
        //Create list of player inputs from the players in the scene
        var playerInputs = new List<PlayerInput> { player1.GetComponent<PlayerInput>(), player2.GetComponent<PlayerInput>(), 
            player3.GetComponent<PlayerInput>(), player4.GetComponent<PlayerInput>() };

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