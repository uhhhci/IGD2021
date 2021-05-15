using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject platform;
    public GameObject bridge;
    public GameObject goal;
    private const float minCenterDistance = 1.5f;
    private const float maxCenterDistance = 3.5f;
    private int currentLevel = 0;
    private Vector3 currentGoal = new Vector3(2, 2.01f, 0);
    private Vector3 currentPlatformCenter = new Vector3(2, 1, 0);

    public Rigidbody NextLevel()
    {
        currentLevel++;
        float nextCenterDistance = Random.Range(minCenterDistance, maxCenterDistance);
        Vector3 nextPlatformCenter = new Vector3(currentPlatformCenter.x - nextCenterDistance, currentPlatformCenter.y, currentPlatformCenter.z);
        Instantiate(platform, nextPlatformCenter, Quaternion.identity);
        float nextGoalOffset = Random.Range(-1.0f, 1.0f);
        Vector3 nextGoal = new Vector3(nextPlatformCenter.x, currentGoal.y, nextPlatformCenter.z + nextGoalOffset);
        Instantiate(goal, nextGoal, Quaternion.identity);

        float xDistanceBetweenGoals = Mathf.Abs(currentGoal.x - nextGoal.x) - 1;
        float zDistanceBetweenGoals = Mathf.Abs(currentGoal.z - nextGoal.z);
        float additionalBridgeLength = Random.value * (1/currentLevel) + 0.1f;
        float bridgeLength = Mathf.Sqrt(Mathf.Pow(xDistanceBetweenGoals, 2) + Mathf.Pow(zDistanceBetweenGoals, 2)) + additionalBridgeLength;
        Vector3 newBridgePosition = currentPlatformCenter + new Vector3(0, 2, -2.5f);
        GameObject newBridge = Instantiate(bridge, newBridgePosition, Quaternion.identity);
        newBridge.gameObject.transform.localScale = new Vector3(bridgeLength, 0.01f, 0.4f);

        currentPlatformCenter = nextPlatformCenter;
        currentGoal = nextGoal;
        return newBridge.GetComponent<Rigidbody>();
    }

    public Vector3 GetCurrentGoal()
    {
        return currentGoal;
    }
}
