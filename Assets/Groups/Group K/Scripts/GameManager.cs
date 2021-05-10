using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Rigidbody leftBridge;
    public LeftBridgeMovement leftBridgeMovement;
    private Vector2 nextGoal = new Vector2(0, 0);
    public GameObject minifigure1;
    public GameObject levelManager;

    public void ReleaseBridgeSegments()
    {
        leftBridge.useGravity = true;
        leftBridgeMovement.enabled = false;
        float yPositionFigure1 = minifigure1.GetComponent<Transform>().position.y;
        Vector3 goal = levelManager.GetComponent<LevelManager>().GetCurrentGoal();
        minifigure1.GetComponent<MinifigController>().MoveTo(goal, onComplete: CelebrateSuccess, moveDelay: 2.0f, speedMultiplier: 0.5f);
        //LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        leftBridge = levelManager.GetComponent<LevelManager>().NextLevel();
        leftBridgeMovement.SetBridgeBody(leftBridge);
    }

    private void CelebrateSuccess()
    {
        minifigure1.GetComponent<MinifigController>().PlaySpecialAnimation(MinifigController.SpecialAnimation.Dance);
    }

    private void Start()
    {
        LoadNextLevel();
    }
}
