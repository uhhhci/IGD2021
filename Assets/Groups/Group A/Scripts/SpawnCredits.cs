using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCredits : MonoBehaviour
{
    public float timeToSpawnInSeconds;
    private float lastSpawnTime;
    public GameObject creditPrefab;
    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawnTime >= timeToSpawnInSeconds) {
            Instantiate(creditPrefab, transform);
            lastSpawnTime = Time.time;
        }
    }
}
