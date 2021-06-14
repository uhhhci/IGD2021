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
    public int TimeUntilLvlUp = 60;

    private AudioSource SoundEffect;
    private float FireRateCounter;
    private float TimeCounter = 0.0f;
    public int Level;
    private bool LevelSet = false;

    private void Awake()
    {
        SoundEffect = GetComponent<AudioSource>();
    }

    void Update()
    {
        FireRateCounter += Time.deltaTime;
        TimeCounter += Time.deltaTime;
        if ((int) TimeCounter % TimeUntilLvlUp == 0 && LevelSet == false) // Set the level every 60 Seconds up
        {
            Level += 1;
            LevelSet = true;
            
        }
        // Debug.Log((int) TimeCounter % 2);
        if ((int) TimeCounter % 2 == 1)
        {
            LevelSet = false;
        }
    }

    public void Fire(string Tag)
    {
        if (Tag == "Boundary") Level = 1;

        float cooldown;

        if (Tag == "Player") {
            cooldown = (FireRate / (Level * 0.5f));
        }
        else
        {
            cooldown = FireRate / Level;
        }

        if (FireRateCounter >= cooldown)
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
