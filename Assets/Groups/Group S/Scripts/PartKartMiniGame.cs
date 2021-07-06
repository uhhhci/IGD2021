using System;
using System.Collections.Generic;
using System.Linq;
using Groups.Group_S.AI;
using Groups.Group_S.Building;
using Groups.Group_S.Driving;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

namespace Groups.Group_S
{
    public class PartKartMiniGame : MiniGame
    {
        public GameObject buildingFinishedUI;
        public Animator cameraAnimator;
        public InputActionAsset controllers;
        [Header("Player controlled Objects")] public List<MinifigControllerGroupS> playerMinifigs;
        public List<Drivable> playerCars;

        [Header("AI Driver Settings")] public Transform[] aiDriverWaypoints;
        public float aiDriverWaypointThreshold = 1.5f;
        public float aiDriverSteeringThreshold = 0.1f;

        public event Action OnBuildingFinished;
        private bool _buildingFinished;

        private bool[] _playerIsAI = new bool[4];

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

            _playerIsAI[0] = PlayerPrefs.GetString(InputManager.PLAYER_1_AI).Equals("True");
            _playerIsAI[1] = PlayerPrefs.GetString(InputManager.PLAYER_2_AI).Equals("True");
            _playerIsAI[2] = PlayerPrefs.GetString(InputManager.PLAYER_3_AI).Equals("True");
            _playerIsAI[3] = PlayerPrefs.GetString(InputManager.PLAYER_4_AI).Equals("True");

            DeactivateCars();
            ActivateMinifigs();
        }

        private void ActivateMinifigs()
        {
            for (int i = 0; i < playerMinifigs.Count; i++)
            {
                var minifig = playerMinifigs[i];
                minifig.gameObject.SetActive(true);
                if (!_playerIsAI[i])
                {
                    minifig.gameObject.GetComponent<AiPlayer>().enabled = false;
                }
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
            for (int i = 0; i < playerCars.Count; i++)
            {
                var car = playerCars[i];
                car.gameObject.SetActive(true);
                
                if (_playerIsAI[i])
                {
                    var aiDriver = car.gameObject.AddComponent<AiDriver>();
                    aiDriver.waypoints = aiDriverWaypoints;
                    aiDriver.steeringThreshold = aiDriverSteeringThreshold;
                    aiDriver.waypointThreshold = aiDriverWaypointThreshold;
                    
                    var navMeshAgent = car.GetComponent<NavMeshAgent>();
                    navMeshAgent.speed = 100;
                    navMeshAgent.angularSpeed = 120;
                    navMeshAgent.acceleration = 100;

                    car.GetComponent<PlayerInput>().enabled = false;
                }
            }

            foreach (var car in playerCars)
            {
                car.InitializeDrivable();
            }
            
            InputManager.Instance.AssignPlayerInput(playerCars
                .Select(i => i.gameObject.GetComponent<PlayerInput>())
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