using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameController_G : MiniGame, IPowerUpEvents
{
    //GameController_G is our MiniGame
    public static GameController_G main;

    public List<GameObject> Players = new List<GameObject>();
    public GameObject PassivePlayer;

    private bool GamePlaying = false;
    private List<PowerUp> ActivePowerUps;
    private List<GameObject> AllPlayers = new List<GameObject>();

    void Awake()
    {
        if (Players.Count == 0)
        {
            Debug.Log("No Players linked!");
            return;
        }
        if (PassivePlayer == null)
        {
            Debug.Log("No 4th Player linked!");
            return;
        }

        ActivePowerUps = new List<PowerUp>();
    }

    void Start()
    {
        Application.targetFrameRate = 60;

        foreach (GameObject player in Players)
        {
            AllPlayers.Add(player);
        }
        AllPlayers.Add(PassivePlayer);

    }

    void Update()
    {
        if (GamePlaying && (Players.Count == 0 || TimerController.instance.GetTimeLeft() < 0.0f))
        {
            EndGame();
        }
    }

    public override string getDisplayName()
    {
        return "Rapid Fire";
    }

    public override string getSceneName()
    {
        return "RapidFire";
    }

    public override MiniGameType getMiniGameType()
    {
        return MiniGameType.singleVsTeam;
    }

    public List<PlayerInput> GetAllPlayerInputs()
    {
        List<PlayerInput> playerInputs = new List<PlayerInput>();

        foreach (GameObject player in AllPlayers)
        {
            if (player.GetComponent<PlayerInput>() != null)
            {
                playerInputs.Add(player.GetComponent<PlayerInput>());
            }
        }
        return playerInputs;
    }

    public void BeginGame()
    {
        TimerController.instance.BeginTimer();
        GamePlaying = true;
        SetPlayerControllersActive(true);

        InputManager.Instance.AssignPlayerInput(GetAllPlayerInputs());
        LoadingManager.Instance.LoadMiniGame(getMiniGameType()); 
    }

    public void EndGame()
    {
        GamePlaying = false;
        TimerController.instance.EndTimer();
        SetPlayerControllersActive(false);

        int[] playerIDs = { 0, 1, 2 };
        int[] passivePlayerId = { 3 };
        if (Players.Count == 0)
        {
            Debug.Log("Single Player wins!");
            MiniGameFinished(passivePlayerId, playerIDs, new int[0], new int[0]);
        }
        else
        {
            Debug.Log("Team wins!");
            MiniGameFinished(playerIDs, passivePlayerId, new int[0], new int[0]);
        }
    }

    public void RemovePlayer(GameObject p)
    {
        Players.RemoveAt(Players.IndexOf(p));
    }

    public void SetPlayerControllersActive(bool b)
    {
        //Disable PlayerController until game starts
        foreach (GameObject player in Players)
        {
            player.GetComponent<PlayerController>().enabled = b;
        }
        PassivePlayer.GetComponent<PassivePlayerController>().enabled = b;
    }
    void IPowerUpEvents.OnPowerUpCollected(PowerUp powerUp, Player_G player)
    {
        // We dont bother storing those that expire immediately
        if (!powerUp.ExpiresImmediately)
        {
            ActivePowerUps.Add(powerUp);
            //UpdateActivePowerUpUi();
        }
    }
    void IPowerUpEvents.OnPowerUpExpired(PowerUp powerUp, Player_G player)
    {
        ActivePowerUps.Remove(powerUp);
        //UpdateActivePowerUpUi();
    }
}
