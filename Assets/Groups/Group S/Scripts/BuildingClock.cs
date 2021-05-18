using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class BuildingClock : MonoBehaviour
{
    public int maxBuildingTime = 60;
    private Text timerDisplay;

    private double _currentTime = 0;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        timerDisplay = GetComponent<Text>();
    }

    void Update()
    {
        _currentTime += Time.deltaTime;
        int displayedTime = (int) Math.Ceiling(maxBuildingTime - _currentTime);
        if (displayedTime > 0)
        {
            timerDisplay.text = displayedTime.ToString(CultureInfo.InvariantCulture);
        }
        else
        {
            timerDisplay.text = "Times up!";
            _gameManager.FinishBuilding();
        }
    }
}
