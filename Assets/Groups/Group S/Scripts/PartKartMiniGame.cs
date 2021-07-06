using System;
using System.Collections.Generic;
using System.Linq;
using Groups.Group_S.Building;
using Groups.Group_S.Driving;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

namespace Groups.Group_S
{
    public class PartKartMiniGame : MiniGame
    {
        public GameObject buildingFinishedUI;
        public Animator cameraAnimator;
        [Header("Player controlled Objects")] public List<MinifigControllerGroupS> playerMinifigs;
        public List<Drivable> playerCars;

        public event Action OnBuildingFinished;
        private bool _buildingFinished;

        private List<int> _rankingList = new List<int>();

        #region MiniGame Overrides

        public override string getDisplayName()
        {
            return "PartKart";
        }

        public override string getSceneName()
        {
            return "PartKart";
        }

        public override MiniGameType getMiniGameType()
        {
            return MiniGameType.freeForAll;
        }

        #endregion

        private void Awake()
        {
            Assert.AreEqual(playerMinifigs.Count, playerCars.Count);
        }

        private void Start()
        {
            _buildingFinished = false;
            
            // TODO: This is hardcoded. What are we supposed to do?
            PlayerPrefs.SetString("PLAYER1_NAME", "Brenda");
            PlayerPrefs.SetString("PLAYER2_NAME", "Jovanna");
            PlayerPrefs.SetString("PLAYER3_NAME", "Myriem");
            PlayerPrefs.SetString("PLAYER4_NAME", "Jose");
            
            DeactivateCars();
            ActivateMinifigs();
        }

        private void ActivateMinifigs()
        {
            foreach (var minifig in playerMinifigs)
            {
                minifig.gameObject.SetActive(true);
            }
            InputManager.Instance.AssignPlayerInput(playerMinifigs
                .Select(i => i.GetComponent<PlayerInput>())
                .ToList());
        }

        private void DeactivateMinifigs()
        {
            foreach (var minifig in playerMinifigs)
            {
                minifig.gameObject.SetActive(false);
            }
        }

        private void ActivateCars()
        {
            foreach (var car in playerCars)
            {
                car.gameObject.SetActive(true);
            }
            InputManager.Instance.AssignPlayerInput(playerCars
                .Select(i => i.GetComponent<PlayerInput>())
                .ToList());
        }

        private void DeactivateCars()
        {
            foreach (var car in playerCars)
            {
                car.gameObject.SetActive(false);
            }
        }
        
        public void FinishBuilding()
        {
            if (!_buildingFinished)
            {
                _buildingFinished = true;
                buildingFinishedUI.SetActive(true);
                cameraAnimator.enabled = true;
                Invoke(nameof(OnLoadRacingViewFinished), 3f);
                DeactivateMinifigs();
                OnBuildingFinished?.Invoke();
            }
        }

        private void OnLoadRacingViewFinished()
        {
            buildingFinishedUI.SetActive(false);
            cameraAnimator.enabled = false;
            ActivateCars();
        }

        public void KartFinishedRace(Drivable kart)
        {
            int kartIndex = playerCars.FindIndex(drivable => drivable == kart) + 1;
            if (!_rankingList.Contains(kartIndex))
            {
                _rankingList.Add(kartIndex);
                Debug.Log("Kart finished! " + kartIndex);
            }

            // All cars finished
            if (_rankingList.Count == playerCars.Count)
            {
                MiniGameFinished(new []{_rankingList[0]}, new int[]{_rankingList[1]}, new int[]{_rankingList[2]}, new int[]{_rankingList[3]});
            }
        }
    }
}