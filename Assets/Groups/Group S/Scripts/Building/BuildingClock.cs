using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Groups.Group_S
{
    public class BuildingClock : MonoBehaviour
    {
        public int maxBuildingTime = 60;
        private Text timerDisplay;

        private double _currentTime = 0;
        private PartKartMiniGame _gameManager;

        private void Start()
        {
            _gameManager = FindObjectOfType<PartKartMiniGame>();
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
                timerDisplay.text = "";
                _gameManager.FinishBuilding();
            }
        }
    }
}
