using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingGame : MiniGame
{

    public GameObject myPlayer;
    public GameObject secondPlayer;

    public override string getDisplayName(){
        return "My Awesome Game!";
    }
    public override string getSceneName(){
        return "MiniGameTesting";
    }

    public override MiniGameType getMiniGameType()
    {
        return MiniGameType.freeForAll;
    }

    void Start()
    {
        //LoadingManager.Instance.LoadMiniGameTest(MiniGameType.freeForAll);

        //Create list of player inputs from the players in the scene
        var playerInputs = new List<PlayerInput> { myPlayer.GetComponent<PlayerInput>(), secondPlayer.GetComponent<PlayerInput>() };

        //Character customizaation
        InputManager.Instance.ApplyPlayerCustomization(myPlayer, 1);
        InputManager.Instance.ApplyPlayerCustomization(secondPlayer, 2);

        //This assigns the player input in the order they were given in the array
        List<string> ids = new List<string> { "1", "2" };
        InputManager.Instance.AssignPlayerInput(playerInputs, ids);

        PlayerPrefs.SetString("PLAYER1_NAME", "Brenda");
        PlayerPrefs.SetString("PLAYER2_NAME", "Jovanna");
        PlayerPrefs.SetString("PLAYER3_NAME", "Myriem");
        PlayerPrefs.SetString("PLAYER4_NAME", "Jose");


        //Different configurations for the final scores and Game Over
        //base.MiniGameFinished(new int []{1,2}, new int []{3,4}, new int []{},new int []{});
        //MiniGameFinished(new int []{3,2,4}, new int []{1}, new int []{},new int []{});
      
        PlayerPrefs.SetString("PLAYER1_NAME", "RED");
        PlayerPrefs.SetString("PLAYER2_NAME", "PINK");
        PlayerPrefs.SetString("PLAYER3_NAME", "YELLOW");
        PlayerPrefs.SetString("PLAYER4_NAME", "BLUE");

        //base.MiniGameFinished(new int []{1,2}, new int []{3,4}, new int []{},new int []{});
        //MiniGameFinished(new int []{3,2,4}, new int []{1}, new int []{},new int []{});
        //base.MiniGameFinished(new int []{2}, new int []{4}, new int []{1},new int []{3});


        Debug.Log(PlayerPrefs.GetInt("PLAYER1_PLACE"));
        Debug.Log(PlayerPrefs.GetInt("PLAYER2_PLACE"));
        Debug.Log(PlayerPrefs.GetInt("PLAYER3_PLACE"));
        Debug.Log(PlayerPrefs.GetInt("PLAYER4_PLACE"));

    }
}