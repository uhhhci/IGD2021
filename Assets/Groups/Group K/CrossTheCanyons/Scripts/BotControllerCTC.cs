using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotControllerCTC : MonoBehaviour
{
    public LevelManager levelManager;
    private GameState gameState = new GameState();
    private static float inaccuracy = 1.0f;
    private static float angleInaccuracy = 40.0f;
    public Vector2 GenerateInput(bool vertical, bool leftPlayer)
    {
        float xInaccuracy = Random.value*inaccuracy - inaccuracy/2;
        float yInaccuracy = Random.value*inaccuracy - inaccuracy/2;
        float rotInaccuracy = Random.value*angleInaccuracy - angleInaccuracy/2;

        UpdateGameState();
        Vector2 optimalPosition = gameState.StartPosition(leftPlayer) + (gameState.GoalPosition(leftPlayer) - gameState.StartPosition(leftPlayer))/2;
        Vector2 targetedPosition = new Vector2(optimalPosition.x + xInaccuracy, optimalPosition.y + yInaccuracy);
        Vector2 straightAhead = new Vector2(gameState.GoalPosition(leftPlayer).x, gameState.StartPosition(leftPlayer).y);
        float adjacent = (straightAhead - gameState.StartPosition(leftPlayer)).magnitude;
        float hypotenuse = (gameState.GoalPosition(leftPlayer) - gameState.StartPosition(leftPlayer)).magnitude;
        int clockwiseSign = gameState.GoalPosition(leftPlayer).y > gameState.StartPosition(leftPlayer).y? 1 : -1;
        float optimalRotation = clockwiseSign * Mathf.Acos(adjacent/hypotenuse) * Mathf.Rad2Deg;
        float targetedRotation = optimalRotation + rotInaccuracy;
        int xMovement = targetedPosition.x > gameState.CranePosition(leftPlayer).x? -1 : 1;
        int yMovement = targetedPosition.y > gameState.CranePosition(leftPlayer).y? 1 : -1;
        bool clockwise = targetedRotation - gameState.CraneRotation(leftPlayer) > 0;

        if (vertical)
        {
            int rotation = !clockwise? 1 : 0;
            return new Vector2(rotation, xMovement);
        }
        else
        {
            int rotation = clockwise? 1 : 0;
            return new Vector2(yMovement, rotation);
        }
    }

    private void UpdateGameState()
    {
        (Vector3 leftGoal, Vector3 rightGoal) = levelManager.GetCurrentGoals();
        gameState.leftGoalPosition = new Vector2(leftGoal.x, leftGoal.z);
        gameState.rightGoalPosition = new Vector2(rightGoal.x, rightGoal.z);
        (Vector3 leftStart, Vector3 rightStart) = levelManager.GetPreviousGoals();
        gameState.leftStartPosition = new Vector2(leftStart.x, leftStart.z);
        gameState.rightStartPosition = new Vector2(rightStart.x, rightStart.z);
        (GameObject leftBridge, GameObject rightBridge) = levelManager.GetCurrentBridges();
        gameState.leftCranePosition = new Vector2(leftBridge.transform.position.x, leftBridge.transform.position.z);
        gameState.rightCranePosition = new Vector2(rightBridge.transform.position.x, rightBridge.transform.position.z);
        float leftAngle = leftBridge.transform.rotation.eulerAngles.y;
        float rightAngle = rightBridge.transform.rotation.eulerAngles.y;
        gameState.leftCraneRotation = leftAngle < 180? leftAngle : leftAngle - 360.0f;
        gameState.rightCraneRotation = rightAngle < 180? rightAngle : rightAngle - 360.0f;
    }

    private class GameState
    {
        public Vector2 leftStartPosition;
        public Vector2 leftGoalPosition;
        public Vector2 leftCranePosition;
        public float leftCraneRotation;
        public Vector2 rightStartPosition;
        public Vector2 rightGoalPosition;
        public Vector2 rightCranePosition;
        public float rightCraneRotation;

        public Vector2 StartPosition(bool left)
        {
            return left? leftStartPosition : rightStartPosition;
        }

        public Vector2 GoalPosition(bool left)
        {
            return left? leftGoalPosition : rightGoalPosition;
        }
        
        public Vector2 CranePosition(bool left)
        {
            return left? leftCranePosition : rightCranePosition;
        }

        public float CraneRotation(bool left)
        {
            return left? leftCraneRotation : rightCraneRotation;
        }
    }
}
