﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{

    bool minifigure1_isDead = false;
    bool minifigure2_isDead = false;
    public GameObject minifigure1;
    public GameObject minifigure2;
    public GameManagerK gameManager;
    public LevelManager levelManager;
    void Update()
    {
        if (!minifigure1_isDead && minifigure1.transform.position.y < 0.5f)
        {
            minifigure1.GetComponent<MinifigControllerModified>().ClearMoves();
            minifigure1_isDead = true;
            LeftPlayerDead();
        }

        if (!minifigure2_isDead && minifigure2.transform.position.y < 0.5f)
        {
            minifigure2.GetComponent<MinifigControllerModified>().ClearMoves();
            minifigure2_isDead = true;
            RightPlayerDead();
        }

        if (minifigure1_isDead && minifigure2_isDead)
        {
            gameManager.GameOver();
        }
    }

    private void LeftPlayerDead()
    {
        levelManager.LeftPlayerFinalLevel = levelManager.GetCurrentLevel();
        Debug.Log("Left Player Final Level: " + levelManager.LeftPlayerFinalLevel);
    }

    private void RightPlayerDead()
    {
        levelManager.RightPlayerFinalLevel = levelManager.GetCurrentLevel();
        Debug.Log("Right Player Final Level: " + levelManager.RightPlayerFinalLevel);
    }

    public bool IsLeftPlayerDead()
    {
        return minifigure1_isDead;
    }

    public bool IsRightPlayerDead()
    {
        return minifigure2_isDead;
    }
}
