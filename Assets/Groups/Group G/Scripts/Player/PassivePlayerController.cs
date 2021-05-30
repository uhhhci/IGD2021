using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PassivePlayerController : MonoBehaviour
{
    public float Speed = 25.0f;
    public float Tilt = 1.0f;
    public Boundary Boundary;
    public WeaponSystem[] WeaponSystems;
    public float SlowRate = 30f;
    public float SlowDuration = 5f;
    public float SlowMultiplier = 0.1f;
    public Text SlowCooldownText;

    public GameObject[] WaveHazards;
    public Vector3 WaveSpawnValues;
    public int HazardCount = 3;
    public float WaveRate = 5.0f;
    public Text WaveCooldownText;

    private Vector2 Movement;
    private float NextWave;
    private float NextSlow;
    private int CurrentWeaponIndex = 0;
    private GameController GameController;
    AudioSource AudioSource;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            GameController = gameControllerObject.GetComponent<GameController>();
        }
        if (GameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        string controlScheme = GetComponent<PlayerInput>().defaultControlScheme;
        GetComponent<PlayerInput>().SwitchCurrentControlScheme(controlScheme, Keyboard.current);

        GameObject weapon = Instantiate(WeaponSystems[CurrentWeaponIndex].Bullet, WeaponSystems[CurrentWeaponIndex].ShotSpawnPoints[0].transform.position, WeaponSystems[CurrentWeaponIndex].ShotSpawnPoints[0].transform.rotation);
        weapon.name = "CurrentWeapon";
        weapon.transform.parent = gameObject.transform;
        weapon.transform.position = WeaponSystems[CurrentWeaponIndex].ShotSpawnPoints[0].transform.position;
        weapon.GetComponent<Rigidbody>().isKinematic = true;
        weapon.GetComponent<Collider>().enabled = false;
        weapon.GetComponent<Mover>().enabled = false;
        weapon.transform.Find("CanvasHPBar").gameObject.SetActive(false);
    }
    public void UpdateWeaponByIndex(int index)
    {
        CurrentWeaponIndex = Mathf.Clamp(index, 0, WeaponSystems.Length - 1);
        UpdateWeaponVisualization();
    }

    public void UpdateWeaponVisualization()
    {
        
        if(gameObject.transform.Find("CurrentWeapon").gameObject != null)
        {
            GameObject.Destroy(gameObject.transform.Find("CurrentWeapon").gameObject);
        }
        
        GameObject weapon = Instantiate(WeaponSystems[CurrentWeaponIndex].Bullet, WeaponSystems[CurrentWeaponIndex].ShotSpawnPoints[0].transform.position, WeaponSystems[CurrentWeaponIndex].ShotSpawnPoints[0].transform.rotation);
        weapon.name = "CurrentWeapon";
        weapon.transform.parent = gameObject.transform;
        weapon.transform.position = WeaponSystems[CurrentWeaponIndex].ShotSpawnPoints[0].transform.position;
        weapon.GetComponent<Rigidbody>().isKinematic = true;
        weapon.GetComponent<Collider>().enabled = false;
        weapon.GetComponent<Mover>().enabled = false;
        weapon.transform.Find("CanvasHPBar").gameObject.SetActive(false);
        
    }

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        //cooldown for next slow
        float slowCooldown = (NextSlow - Time.time);
        if (slowCooldown > 0)
        {
            SlowCooldownText.text = "Slow: " + (int)slowCooldown;
        }
        else
        {
            SlowCooldownText.text = "Slow: READY";
        }

        //cooldown for next wave
        float waveCooldown = (NextWave - Time.time);
        if (waveCooldown > 0)
        {
            WaveCooldownText.text = "Spawn Wave: " + (int)waveCooldown;
        }
        else
        {
            WaveCooldownText.text = "Spawn Wave: READY";
        }
    }

    //for physics
    void FixedUpdate()
    {
        //only move on x-axis
        Vector3 movement = new Vector3(Movement.x, 0.0f, 0.0f);
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

        if(input.y > 0)
        {
            // 5 button (upwards) pressed
        }
        if (input.y < 0)
        {
            // 2 button (downwards) pressed
            //slowing players and slowmotion effect
            if (Time.time > NextSlow)
            {
                foreach (GameObject player in GameController.Players)
                {
                    PlayerController controller = player.GetComponent<PlayerController>();
                    controller.SetSpeedBoostOn(SlowMultiplier);
                    StartCoroutine(WaitUntilExpires(controller));
                }
                NextSlow = Time.time + SlowRate;
            }

        }

    }
    IEnumerator WaitUntilExpires(PlayerController controller)
    {
        yield return new WaitForSeconds(SlowDuration);
        controller.SetSpeedBoostOff();
    }

    private void OnMenu()
    {
        print("OnMenu");
    }

    private void OnNorthPress()
    {
        // + button
        string tag = transform.gameObject.tag;
        WeaponSystems[CurrentWeaponIndex].Fire(tag);
    }

    private void OnNorthRelease()
    {
        
    }

    private void OnEastPress()
    {
        // 4 button
        UpdateWeaponByIndex(CurrentWeaponIndex - 1);
    }

    private void OnEastRelease()
    {
        
    }

    private void OnSouthPress()
    {
        // 6 button
        UpdateWeaponByIndex(CurrentWeaponIndex + 1 );
    }
    private void OnSouthRelease()
    {
        
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
            GameObject waveHazard = WaveHazards[Random.Range(0, WaveHazards.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-WaveSpawnValues.x, WaveSpawnValues.x), WaveSpawnValues.y, WaveSpawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(waveHazard, spawnPosition, spawnRotation);
        }
    }
    private void OnWestRelease()
    {
       
    }
}
