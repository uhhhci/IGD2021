using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text EndGameText;
    public List<GameObject> Players = new List<GameObject>();

    private bool GamePlaying;
     void Awake()
    {
        if (Players.Count == 0)
        {
            Debug.Log("No Players linked!");
            return;
        }
    }

    void Start()
    {
        Application.targetFrameRate = 60;
        BeginGame();
    }

    void Update()
    {
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
    }

    public void RemovePlayer(GameObject p)
    {
        Players.RemoveAt(Players.IndexOf(p));
    }
}
