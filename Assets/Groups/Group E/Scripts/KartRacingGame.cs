using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KartRacingGame : MiniGame
{

    public List<GameObject> players;

    public override string getDisplayName(){
        return "Kart Racing";
    }
    public override string getSceneName(){
        return "KartRacingMinigame";
    }

    public override MiniGameType getMiniGameType()
    {
        return MiniGameType.freeForAll;
    }

    private void Start()
    {
        List<PlayerInput> playerInputs = new List<PlayerInput>();
        foreach(GameObject player in players)
        {
            playerInputs.Add(player.GetComponent<PlayerInput>());
        }
        InputManager.Instance.AssignPlayerInput(playerInputs);
        LoadingManager.Instance.LoadMiniGame(MiniGameType.freeForAll);
    }
}