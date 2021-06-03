using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class RhythmGame : MiniGame {

    public GameObject player1, player2, player3, player4;

    public override string getDisplayName() {
        return "Rhythm Game";
    }

    public override string getSceneName()  {
        return "RhythmGameScene";
    }

    public override MiniGameType getMiniGameType() {
        return MiniGameType.freeForAll;
    }

    void Start() {
        var playerInputs = new List<PlayerInput> { 
            player1.GetComponent<PlayerInput>(),
            player2.GetComponent<PlayerInput>(),
            player3.GetComponent<PlayerInput>(),
            player4.GetComponent<PlayerInput>()
        };

        InputManager.Instance.AssignPlayerInput(playerInputs);

        LoadingManager.Instance.LoadMiniGame(getMiniGameType());
    }

    void Update() {
        
        bool myGameEndingCondition = false;
        if (myGameEndingCondition)
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