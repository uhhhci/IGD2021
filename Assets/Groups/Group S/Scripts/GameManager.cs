using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject BuildingFinishedUI;
    public Transform CameraTransform;
    
    private bool buildingFinished = false;
    public void FinishBuilding()
    {
        if (!buildingFinished)
        {
            buildingFinished = true;
            BuildingFinishedUI.SetActive(true);
            Invoke(nameof(LoadRacingView), 3f);
        }
    }

    private void LoadRacingView()
    {
        var position = CameraTransform.position;
        position = new Vector3(position.x, position.y + 10, position.z);
        CameraTransform.position = position;
        BuildingFinishedUI.SetActive(false);
    }
}
