using UnityEngine;

public class GameManagerK : MonoBehaviour
{
    public CrossTheCanyons crossTheCanyons;
    public MinifigControllerModified minifigure1;
    public MinifigControllerModified minifigure2;
    public LevelManager levelManager;
    public GameOverChecker gameOverChecker;
    public BridgeMovement leftBridgeMovement;
    public BridgeMovement rightBridgeMovement;
    public CountdownTimer timer;
    public MoveCamera mainCamera;

    //private fields
    private Rigidbody leftBridge;
    private Rigidbody rightBridge;
    private bool leftPlayerMoveCompleted = false;
    private bool rightPlayerMoveCompleted = false;

    public void ReleaseBridgeSegments()
    {
        leftBridge.useGravity = true;
        rightBridge.useGravity = true;
        leftBridgeMovement.enabled = false;
        rightBridgeMovement.enabled = false;

        (Vector3 leftGoal, Vector3 rightGoal) = levelManager.GetCurrentGoals();
        if (!gameOverChecker.IsLeftPlayerDead())
            minifigure1.MoveTo(leftGoal, moveDelay: 2.0f, speedMultiplier: 0.2f,
                onComplete: () => {minifigure1.PlaySpecialAnimation(MinifigControllerModified.SpecialAnimation.Dance, 
                    onSpecialComplete: x => {StartNextLevel(leftPlayer: true);});});
        if (!gameOverChecker.IsRightPlayerDead())
            minifigure2.MoveTo(rightGoal, moveDelay: 2.0f, speedMultiplier: 0.2f,
                onComplete: () => {minifigure2.PlaySpecialAnimation(MinifigControllerModified.SpecialAnimation.Dance, 
                    onSpecialComplete: x => {StartNextLevel(leftPlayer: false);});});
    }

    private void StartNextLevel(bool leftPlayer)
    {
        if (leftPlayer && !leftPlayerMoveCompleted)
            leftPlayerMoveCompleted = true;
        else if (!leftPlayer && !rightPlayerMoveCompleted)
            rightPlayerMoveCompleted = true;
        
        if ((leftPlayerMoveCompleted && rightPlayerMoveCompleted) || (leftPlayerMoveCompleted && gameOverChecker.IsRightPlayerDead())
            || (gameOverChecker.IsLeftPlayerDead() && rightPlayerMoveCompleted))
        {
            leftPlayerMoveCompleted = false;
            rightPlayerMoveCompleted = false;
            mainCamera.MoveForward(levelManager.DistanceBetweenCurrentPlatforms());
            (leftBridge, rightBridge) = levelManager.NextLevel(gameOverChecker.IsLeftPlayerDead(), gameOverChecker.IsRightPlayerDead());
            timer.ResetTimer();

            if (!gameOverChecker.IsLeftPlayerDead())
            {
                leftBridgeMovement.SetBridgeBody(leftBridge);
                leftBridgeMovement.enabled = true;
            }
            if (!gameOverChecker.IsRightPlayerDead())
            {
                rightBridgeMovement.SetBridgeBody(rightBridge);
                rightBridgeMovement.enabled = true;
            }
        }
    }

    private void Start()
    {
        (leftBridge, rightBridge) = levelManager.Init();
        leftBridgeMovement.SetBridgeBody(leftBridge);
        rightBridgeMovement.SetBridgeBody(rightBridge);
    }

    public void GameOver(int leftPlayerFinalLevel, int rightPlayerFinalLevel)
    {
        Debug.Log("Game Over for both teams!");
        crossTheCanyons.GameOver(leftPlayerFinalLevel, rightPlayerFinalLevel);
    }

}
