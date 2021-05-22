using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Shot;
    public Transform ShotSpawn;
    public float FireRate;
    public float Delay;

    private AudioSource AudioSource;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", Delay, FireRate);
    }

    void Fire()
    {
        Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
        AudioSource.Play();
    }
}
