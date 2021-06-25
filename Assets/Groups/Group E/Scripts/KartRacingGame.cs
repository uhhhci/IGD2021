using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KartRacingGame : MiniGame
{

    public List<GameObject> players;

    public static KartRacingGame Instance;

    public void Awake()
    {
        Instance = this;
    }

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

    private void Update()
    {
    }

    // Sets places and finishes game
    public void finishGame()
    {
        int[] first = { GameManager_E.Instance.firstPlace };
        int[] second = { GameManager_E.Instance.secondPlace };
        int[] third = { GameManager_E.Instance.thirdPlace };
        int[] fourth = { GameManager_E.Instance.fourthPlace };

        Debug.Log("First: " + first[0]);
        Debug.Log("Second: " + second[0]);

        MiniGameFinished(firstPlace: first, secondPlace: second, thirdPlace: third, fourthPlace: fourth);
    }
}