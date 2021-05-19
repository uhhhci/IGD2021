using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Groups.Group_S
{
    public class GameManager : MonoBehaviour
    {
        public GameObject buildingFinishedUI;
        public Transform cameraTransform;
        public Animator cameraAnimator;
        public List<GameObject> carsToEnable;
        public List<GameObject> characterToDisable;

        private bool buildingFinished = false;

        public void FinishBuilding()
        {
            if (!buildingFinished)
            {
                buildingFinished = true;
                buildingFinishedUI.SetActive(true);
                cameraAnimator.enabled = true;
                Invoke(nameof(LoadRacingViewFinished), 3f);
            }
        }

        private void LoadRacingViewFinished()
        {
            buildingFinishedUI.SetActive(false);
            cameraAnimator.enabled = false;
            foreach (var character in characterToDisable)
                character.SetActive(false);
            foreach (var car in carsToEnable)
                car.SetActive(true);
        }
    }
}
