﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float Tilt;
    public Boundary Boundary;
    public WeaponSystem[] WeaponSystems;

    private Vector2 Movement;
    private float SpeedOriginal;
    private int CurrentWeaponIndex = 0;

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

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -Tilt);
    }

    public void SetSpeedBoostOn(float speedMultiplier)
    {
        SpeedOriginal = Speed;
        Speed *= speedMultiplier;
    }

    public void SetSpeedBoostOff()
    {
        Speed = SpeedOriginal;
    }
    
    public void UpdateWeaponByIndex(int index)
    {
        CurrentWeaponIndex = Mathf.Clamp(index, 0, WeaponSystems.Length - 1);
    }
    
    public int GetCurrentWeaponIndex()
    {
        return CurrentWeaponIndex;
    }

    private void OnMoveDpad(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        input.Normalize();
        Movement = input;
        if (input.y > 0)
        {
            // (upwards) pressed
        }
        if (input.y < 0)
        {
            // (downwards) pressed

        }
    }
    private void OnMenu()
    {

    }

    private void OnNorthPress()
    {

    }

    private void OnNorthRelease()
    {

    }

    private void OnEastPress()
    {

    }

    private void OnEastRelease()
    {

    }

    private void OnSouthPress()
    {
        string tag = transform.gameObject.tag;
        WeaponSystems[CurrentWeaponIndex].Fire(tag);
    }
    private void OnSouthRelease()
    {

    }

    private void OnWestPress()
    {

    }

    private void OnWestRelease()
    {

    }
}
