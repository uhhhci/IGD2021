using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    public static SpawnPowerUps instance = null;

    public List<GameObject> spawnablePowerUps = new List<GameObject>();

    public List<GameObject> pickablePowerUps = new List<GameObject>();

    public GameObject RespawnPointsSource;

    public float spawningStartTime = 0f;
    public float spawningRateSecs = 5f;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);
    }

    private void Start()
    {
        InvokeRepeating("spawnPickup", spawningStartTime, spawningRateSecs);
    }

    public void SpawnPowerUp(string powerUpIdentifier, Vector3 position, Quaternion rotation)
    {
        GameObject powerUpPrefab = spawnablePowerUps.Find(prefab => prefab.name == powerUpIdentifier);
        Instantiate(powerUpPrefab, position, rotation);
    }

    private void spawnPickup()
    {
        if(pickablePowerUps.Count >= 1)
        {
            GenerateRings rings = RespawnPointsSource.GetComponent<GenerateRings>();
            Vector3 spawnLocation = rings.getSpawnLocation(randomRing: true);
            spawnLocation.y += 2;
            GameObject pickablePowerUp = pickablePowerUps[Random.Range(0, pickablePowerUps.Count)];
            Instantiate(pickablePowerUp, spawnLocation, Quaternion.Euler(0, 0, 0));
        }
    }
}
