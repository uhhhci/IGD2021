using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PassivePlayerController : MonoBehaviour
{
    public float Speed = 25.0f;
    public float Tilt = 1.0f;
    public Boundary Boundary;
    public GameObject Shot;
    public Transform ShotSpawn;
    public float FireRate = 0.5f;
    public AudioClip ShootAudioClip;


    public GameObject WaveHazard;
    public Vector3 WaveSpawnValues;
    public int HazardCount = 3;
    public float WaveRate = 5.0f;
    

    private Vector2 Movement;
    private float NextFire;
    private float NextWave;

    AudioSource AudioSource;

    private void Start()
    {
        string controlScheme = GetComponent<PlayerInput>().defaultControlScheme;
        GetComponent<PlayerInput>().SwitchCurrentControlScheme(controlScheme, Keyboard.current);
    }

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {

    }

    //for physics
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Movement.x, 0.0f, Movement.y);
        GetComponent<Rigidbody>().velocity = movement * Speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, Boundary.xMin, Boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, Boundary.zMin, Boundary.zMax)
        );

        //GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, this.transform.rotation.y, GetComponent<Rigidbody>().velocity.x * -Tilt);
    }

    private void OnMoveDpad(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        input.Normalize();
        Movement = input;
        Debug.Log("Moving");
    }
    private void OnMenu()
    {
        print("OnMenu");
    }

    private void OnNorthPress()
    {
        print("OnNorthPress");
    }

    private void OnNorthRelease()
    {
        print("OnNorthRelease");
    }

    private void OnEastPress()
    {
        print("OnEastPress");
    }

    private void OnEastRelease()
    {
        print("OnEastRelease");
    }

    private void OnSouthPress()
    {
        print("OnSouthPress");
        if (Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
            if (ShootAudioClip)
            {
                AudioSource.PlayOneShot(ShootAudioClip);
            }
        }
    }
    private void OnSouthRelease()
    {
        print("OnSouthRelease");
    }

    private void OnWestPress()
    {
        if (Time.time > NextWave)
        {
            NextWave = Time.time + WaveRate;
            SpawnWave();
        }
    }

    private void SpawnWave()
    {
        for (int i = 0; i < HazardCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-WaveSpawnValues.x, WaveSpawnValues.x), WaveSpawnValues.y, WaveSpawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(WaveHazard, spawnPosition, spawnRotation);
        }
    }
    private void OnWestRelease()
    {
        print("OnWestRelease");
    }
}
