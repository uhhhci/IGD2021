using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public Text timerText;
    public WhatTheHillGame game;
    private bool finished = false;
    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds); ;
        }
        else
        {
            if (!finished)
            {
                game.myGameEndingCondition = true;
                timeRemaining = 0;
                finished = true;
            }
        }
    }
}
