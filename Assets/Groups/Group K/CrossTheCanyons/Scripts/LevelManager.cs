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
    private int currentLevel = 1;

    public class Level
    {
        public Vector3 platformCenter;
        public Vector3 goal;
        public float bridgeLength;
        public GameObject bridge;   
        public Level(Vector3 platformCenter, Vector3 goal, float bridgeLength)
        {
            this.platformCenter = platformCenter;
            this.goal = goal;
            this.bridgeLength = bridgeLength;
        }
    }
    
    private List<Level> levels = new List<Level>();

    public Rigidbody NextLevel()
    {
        //can create levels well beyond the next level (depending on Init()) but still starts the next level
        CreateNextLevel(levels[levels.Count-1].platformCenter, levels[levels.Count-1].goal, levels.Count);
        currentLevel++;
        return StartLevel(currentLevel);
    }

    public Rigidbody Init()
    {
        levels.Add(new Level(new Vector3(2,1,0), new Vector3(2,2.01f,0), 0)); //add first platform to make levels.Count and currentLevel match in upcoming method calls
        for (int i = 0; i < 20; i++)
            CreateNextLevel(levels[i].platformCenter, levels[i].goal, levels.Count);

        Rigidbody firstBridge = StartLevel(currentLevel);
        return firstBridge;
    }

    private Rigidbody StartLevel(int lvl)
    {
        Instantiate(goal, levels[lvl].goal, Quaternion.identity);
        Vector3 newBridgePosition = levels[lvl-1].platformCenter + new Vector3(0, 2, -2.5f);
        levels[lvl].bridge = Instantiate(bridge, newBridgePosition, Quaternion.identity);
        levels[lvl].bridge.gameObject.transform.localScale = new Vector3(levels[lvl].bridgeLength, 0.01f, 0.4f);
        return levels[lvl].bridge.GetComponent<Rigidbody>();
    }

    private void CreateNextLevel(Vector3 oldPlatformCenter, Vector3 oldGoal, int level)
    {
        float nextCenterDistance = Random.Range(minCenterDistance, maxCenterDistance);
        Vector3 newPlatformCenter = new Vector3(oldPlatformCenter.x - nextCenterDistance, oldPlatformCenter.y, oldPlatformCenter.z);
        Instantiate(platform, newPlatformCenter, Quaternion.identity);
        float newGoalOffset = Random.Range(-1.0f, 1.0f);
        Vector3 newGoal = new Vector3(newPlatformCenter.x, oldGoal.y, newPlatformCenter.z + newGoalOffset);
        float xDistanceBetweenGoals = Mathf.Abs(oldGoal.x - newGoal.x) - 1;
        float zDistanceBetweenGoals = Mathf.Abs(oldGoal.z - newGoal.z);
        float additionalBridgeLength = Random.value * (1/level) + 0.1f;
        float bridgeLength = Mathf.Sqrt(Mathf.Pow(xDistanceBetweenGoals, 2) + Mathf.Pow(zDistanceBetweenGoals, 2)) + additionalBridgeLength;

        levels.Add(new Level(newPlatformCenter, newGoal, bridgeLength));
    }

    public Vector3 GetCurrentGoal()
    {
        return levels[currentLevel].goal;
    }

    public float DistanceBetweenCurrentPlatforms()
    {
        return Mathf.Abs(levels[currentLevel].platformCenter.x - levels[currentLevel-1].platformCenter.x);
    }
}