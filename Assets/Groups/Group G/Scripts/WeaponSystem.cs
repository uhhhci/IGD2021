using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnPoint
{
    public Transform transform;
    public Quaternion rotation;
}

public class WeaponSystem : MonoBehaviour
{
    public SpawnPoint[] ShotSpawnPoints;
    public GameObject Bullet;
    public float FireRate = 1f;

    private AudioSource SoundEffect;
    private float FireRateCounter;

    private void Awake()
    {
        SoundEffect = GetComponent<AudioSource>();
    }

    void Update()
    {
        FireRateCounter += Time.deltaTime;
    }

    public void Fire()
    {
        if(FireRateCounter >= FireRate)
        {
            FireRateCounter = 0;
            
            foreach(var spawnPoint in ShotSpawnPoints)
            {
                Instantiate(Bullet, spawnPoint.transform.position, spawnPoint.rotation);
            }
            if (SoundEffect)
            {
                SoundEffect.Play();
            }
            else Debug.Log("No AudioSource on the WeaponSystem.");
        }
    }
}
