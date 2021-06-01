using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour, IPowerUpEvents
{
    public static GameController main;

    public Text EndGameText;
    public List<GameObject> Players = new List<GameObject>();
    public float timeRemaining = 3;

    private bool GamePlaying;
    private List<PowerUp> ActivePowerUps;
    private bool timerIsRunning = false;

    void Awake()
    {
        if (Players.Count == 0)
        {
            Debug.Log("No Players linked!");
            return;
        }
        ActivePowerUps = new List<PowerUp>();
    }

    void Start()
    {
        timerIsRunning = true;
        Application.targetFrameRate = 60;
        

    }

    void Update()
    {
                if (timerIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                EndGameText.text = timeRemaining.ToString();
            }
            else
            {
                {
                    timeRemaining = 0;
                    timerIsRunning = false;
                    EndGameText.text = "";
                    BeginGame();
                }
            }
        }


        if (GamePlaying && (Players.Count == 0 || TimerController.instance.GetTimeLeft() <= 0.0f))
        {
            EndGame();
        }
    }

    public void BeginGame()
    {

        GamePlaying = true;
        EndGameText.text = "";
        TimerController.instance.BeginTimer();
    }

    public void EndGame()
    {
        GamePlaying = false;
        EndGameText.text = "Game Ended!";
        TimerController.instance.EndTimer();
        if (Players.Count == 0)
        {
            Debug.Log("Single Player wins!");
        }
        else
        {
            Debug.Log("Teams wins!");
        }
    }

    public void RemovePlayer(GameObject p)
    {
        Players.RemoveAt(Players.IndexOf(p));
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
