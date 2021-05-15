using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Rigidbody leftBridge;
    public GameObject minifigure1;
    public LevelManager levelManager;
    public LeftBridgeMovement leftBridgeMovement;
    public CountdownTimer timer;
    public MoveCamera mainCamera;

    public void ReleaseBridgeSegments()
    {
        leftBridge.useGravity = true;
        leftBridgeMovement.enabled = false;
        float yPositionFigure1 = minifigure1.GetComponent<Transform>().position.y;
        Vector3 goal = levelManager.GetCurrentGoal();
        minifigure1.GetComponent<MinifigController>().MoveTo(goal, onComplete: SuccessfullyCrossed, moveDelay: 2.0f, speedMultiplier: 0.2f);
    }

    public void GameOver()
    {
        Debug.Log("Game Over for both teams!");
    }

    private void StartNextLevel(bool cancelSpecial)
    {
        mainCamera.MoveForward(levelManager.DistanceBetweenCurrentPlatforms());
        leftBridge = levelManager.NextLevel();
        leftBridgeMovement.SetBridgeBody(leftBridge);
        timer.ResetTimer();
        leftBridgeMovement.enabled = true;
    }

    private void Start()
    {
        leftBridge = levelManager.Init();
        leftBridgeMovement.SetBridgeBody(leftBridge);
    }

    private void SuccessfullyCrossed()
    {
        minifigure1.GetComponent<MinifigController>().PlaySpecialAnimation(MinifigController.SpecialAnimation.Dance, onSpecialComplete: StartNextLevel);
    }
}
