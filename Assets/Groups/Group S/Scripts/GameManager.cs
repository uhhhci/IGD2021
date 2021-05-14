using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public GameObject buildingFinishedUI;
    public Transform cameraTransform;
    public Animator cameraAnimator;
    
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
    }
}
