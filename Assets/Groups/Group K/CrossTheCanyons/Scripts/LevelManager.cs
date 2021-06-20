using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject platform;
    public GameObject bridge;
    public GameObject goal;
    public GameObject barrier;
    public GameObject ground;
    public CraneMovement leftCrane;
    public CraneMovement rightCrane;
    private const float minCenterDistance = 1.5f;
    private const float maxCenterDistance = 3.5f;
    private const float distanceBridgeToPlatformCenter = 3.0f;
    private Vector3 centerOffset = new Vector3(0, 0, 0.5f);
    private int currentLevel = 1;
    public int LeftPlayerFinalLevel {get; set;}
    public int RightPlayerFinalLevel {get; set;}

    public class Level
    {
        public Vector3 platformCenter;
        public Vector3 leftGoal;
        public Vector3 rightGoal;
        public float bridgeLength;
        public float distanceBetweenPlatforms;
        public GameObject leftBridge;
        public GameObject rightBridge;   
        public Level(Vector3 platformCenter, Vector3 leftGoal, Vector3 rightGoal, float bridgeLength, float distanceBetweenPlatforms)
        {
            this.platformCenter = platformCenter;
            this.leftGoal = leftGoal;
            this.rightGoal = rightGoal;
            this.bridgeLength = bridgeLength;
            this.distanceBetweenPlatforms = distanceBetweenPlatforms;
        }
    }
    
    private List<Level> levels = new List<Level>();
    private List<GameObject> barriers = new List<GameObject>();

    public (Rigidbody leftBridge, Rigidbody rightBridge) NextLevel(bool leftPlayerDead, bool rightPlayerDead)
    {
        //can create levels well beyond the next level (depending on Init()) but still starts the next level
        CreateNextLevel(levels[levels.Count-1].platformCenter, levels[levels.Count-1].leftGoal, levels.Count);
        currentLevel++;
        return StartLevel(currentLevel, leftPlayerDead, rightPlayerDead);
    }

    public (Rigidbody leftBridge, Rigidbody rightBridge) Init()
    {
        for (int i = 0; i < 8; i++)
        {
            barriers.Add(Instantiate(barrier, new Vector3(0,0,0), Quaternion.identity));
        }
        levels.Add(new Level(new Vector3(2,0,0), new Vector3(2,2.01f,-2), new Vector3(2,2.01f,2), 0, 0)); //add first platform to make levels.Count and currentLevel match in upcoming method calls
        for (int i = 0; i < 20; i++)
            CreateNextLevel(levels[i].platformCenter, levels[i].leftGoal, levels.Count);

        return StartLevel(currentLevel, leftPlayerDead: false, rightPlayerDead: false);
    }

    private (Rigidbody leftBridge, Rigidbody rightBridge) StartLevel(int lvl, bool leftPlayerDead, bool rightPlayerDead)
    {
        Vector3 leftRightOffset = new Vector3(0, 0, platform.transform.localScale.z/2);
        UpdateBarriers(lvl, leftRightOffset);
        
        float bridgeWidth = 0.4f;
        float spawnOffset = platform.transform.localScale.x/2 - levels[lvl].bridgeLength/2;
        Vector3 newBridgePosition = levels[lvl-1].platformCenter 
                + new Vector3(spawnOffset, distanceBridgeToPlatformCenter, -platform.transform.localScale.z/2 + bridgeWidth/2);

        if (!leftPlayerDead)
        {
            Instantiate(goal, levels[lvl].leftGoal, Quaternion.identity);
            levels[lvl].leftBridge = Instantiate(bridge, newBridgePosition - leftRightOffset + centerOffset, Quaternion.identity);
            levels[lvl].leftBridge.gameObject.transform.localScale = new Vector3(levels[lvl].bridgeLength, bridge.transform.localScale.y, bridgeWidth);
            leftCrane.MoveIntoScene(true, levels[lvl].leftBridge);
        }
        if (!rightPlayerDead)
        {
            Instantiate(goal, levels[lvl].rightGoal, Quaternion.identity);
            levels[lvl].rightBridge = Instantiate(bridge, newBridgePosition + leftRightOffset*3 - new Vector3(0,0,bridgeWidth) - centerOffset, Quaternion.identity);
            levels[lvl].rightBridge.gameObject.transform.localScale = new Vector3(levels[lvl].bridgeLength, 0.01f, bridgeWidth);
            rightCrane.MoveIntoScene(false, levels[lvl].rightBridge);
        }

        ground.transform.position = new Vector3(ground.transform.position.x - levels[lvl].distanceBetweenPlatforms,
                ground.transform.position.y, ground.transform.position.z);

        //if necessary create placeholders to prevent nullpointer errors
        if (!levels[lvl].leftBridge)
        {
            levels[lvl].leftBridge = new GameObject();
            levels[lvl].leftBridge.AddComponent<Rigidbody>();
        }
        if (!levels[lvl].rightBridge)
        {
            levels[lvl].rightBridge = new GameObject();
            levels[lvl].rightBridge.AddComponent<Rigidbody>();
        }

        return (levels[lvl].leftBridge.GetComponent<Rigidbody>(), levels[lvl].rightBridge.GetComponent<Rigidbody>());
    }

    private void UpdateBarriers(int lvl, Vector3 leftRightOffset)
    {
        Vector3 oldPlatformCenter = levels[lvl-1].platformCenter;
        Vector3 newPlatformCenter = levels[lvl].platformCenter;
        float platformWidth = platform.transform.localScale.z;
        float platformDepth = platform.transform.localScale.x;
        float distanceBetweenPlatforms = Mathf.Abs(newPlatformCenter.x - oldPlatformCenter.x);
        //Left Barriers
        //top barrier
        barriers[0].transform.position = new Vector3(newPlatformCenter.x - platformDepth/2, newPlatformCenter.y + distanceBridgeToPlatformCenter, newPlatformCenter.z) 
                                            - leftRightOffset;
        barriers[0].transform.localScale = new Vector3(0, 2, platformWidth);
        //right barrier
        barriers[1].transform.position = new Vector3(oldPlatformCenter.x - distanceBetweenPlatforms/2,
                                                        newPlatformCenter.y + distanceBridgeToPlatformCenter, newPlatformCenter.z + platformWidth/2) - leftRightOffset;
        barriers[1].transform.localScale = new Vector3(distanceBetweenPlatforms + platformDepth, 2, 0);
        //left barrier
        barriers[2].transform.position = new Vector3(oldPlatformCenter.x - distanceBetweenPlatforms/2,
                                                        oldPlatformCenter.y + distanceBridgeToPlatformCenter, newPlatformCenter.z - platformWidth/2) - leftRightOffset;
        barriers[2].transform.localScale = new Vector3(distanceBetweenPlatforms + platformDepth, 2, 0);
        //lower barrier
        barriers[3].transform.position = new Vector3(oldPlatformCenter.x + platformDepth/2, oldPlatformCenter.y + distanceBridgeToPlatformCenter, oldPlatformCenter.z)
                                             - leftRightOffset;
        barriers[3].transform.localScale = new Vector3(0, 2, platformWidth);

        //Right Barriers
        barriers[4].transform.position = new Vector3(newPlatformCenter.x - platformDepth/2, newPlatformCenter.y + distanceBridgeToPlatformCenter, newPlatformCenter.z) 
                                            + leftRightOffset;
        barriers[4].transform.localScale = new Vector3(0, 2, platformWidth);
        //right barrier
        barriers[5].transform.position = new Vector3(oldPlatformCenter.x - distanceBetweenPlatforms/2,
                                                        newPlatformCenter.y + distanceBridgeToPlatformCenter, newPlatformCenter.z + platformWidth/2) + leftRightOffset;
        barriers[5].transform.localScale = new Vector3(distanceBetweenPlatforms + platformDepth, 2, 0);
        //left barrier
        barriers[6].transform.position = new Vector3(oldPlatformCenter.x - distanceBetweenPlatforms/2,
                                                        oldPlatformCenter.y + distanceBridgeToPlatformCenter, newPlatformCenter.z - platformWidth/2) + leftRightOffset;
        barriers[6].transform.localScale = new Vector3(distanceBetweenPlatforms + platformDepth, 2, 0);
        //lower barrier
        barriers[7].transform.position = new Vector3(oldPlatformCenter.x + platformDepth/2, oldPlatformCenter.y + distanceBridgeToPlatformCenter, oldPlatformCenter.z)
                                             + leftRightOffset;
        barriers[7].transform.localScale = new Vector3(0, 2, platformWidth);

        foreach (GameObject barrier in barriers)
        {
            barrier.SetActive(false);
        }
    }

    private void CreateNextLevel(Vector3 oldPlatformCenter, Vector3 oldLeftGoal, int level)
    {
        float nextCenterDistance = Random.Range(minCenterDistance, maxCenterDistance);
        Vector3 newPlatformCenter = new Vector3(oldPlatformCenter.x - nextCenterDistance, oldPlatformCenter.y, oldPlatformCenter.z);
        Vector3 leftRightOffset = new Vector3(0, 0, platform.transform.localScale.z/2);
        Instantiate(platform, newPlatformCenter - leftRightOffset, Quaternion.identity);
        Instantiate(platform, newPlatformCenter + leftRightOffset, Quaternion.identity);
        float newGoalOffset = Random.Range(-0.5f, 1.5f);
        Vector3 newLeftGoal = new Vector3(newPlatformCenter.x, oldLeftGoal.y, newPlatformCenter.z + newGoalOffset) - leftRightOffset;
        Vector3 newRightGoal = new Vector3(newPlatformCenter.x, oldLeftGoal.y, newPlatformCenter.z - newGoalOffset) + leftRightOffset;
        float xDistanceBetweenGoals = Mathf.Abs(oldLeftGoal.x - newLeftGoal.x) - 1;
        float zDistanceBetweenGoals = Mathf.Abs(oldLeftGoal.z - newLeftGoal.z);
        float additionalBridgeLength = 10/(level+10) + 0.1f;
        float bridgeLength = Mathf.Sqrt(Mathf.Pow(xDistanceBetweenGoals, 2) + Mathf.Pow(zDistanceBetweenGoals, 2)) + additionalBridgeLength;

        levels.Add(new Level(newPlatformCenter, newLeftGoal, newRightGoal, bridgeLength, nextCenterDistance - platform.transform.localScale.x));
    }

    public (Vector3 leftGoal, Vector3 rightGoal) GetCurrentGoals()
    {
        return (levels[currentLevel].leftGoal, levels[currentLevel].rightGoal);
    }

    public float DistanceBetweenCurrentPlatforms()
    {
        return Mathf.Abs(levels[currentLevel].platformCenter.x - levels[currentLevel-1].platformCenter.x);
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void ActivateBarriers()
    {
        foreach (GameObject barrier in barriers)
        {
            barrier.SetActive(true);
        }
    }
}