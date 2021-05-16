using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public enum Axle
{
    Front,
    Rear
}

[Serializable]
public struct Wheel
{
    public GameObject model;
    public WheelCollider collider;
    public Axle axle;
}

public class CarController : MonoBehaviour
{

    private Vector2 movement;
    private Rigidbody rb;
    private bool backwards = false;
    private bool handbrake = false;

    public float maxAcceleration = 20.0f;
    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 45.0f;
    public float maxVelocity = 30.0f;
    public List<Wheel> wheels;
    public Vector3 centerOfMass;
    public Vector3 wheelRotationOffset;
    public float downForce = 10.0f;
    

    void FixedUpdate()
    {
        CheckDrivingDirection(rb);
        Move();
        Turn();
        ApplyDownForce();
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
    }

    void Update()
    {
        AnimateWheels();
    }

    private void Move()
    {
        foreach (Wheel wheel in wheels)
        {
            // driving forwards --> accelerate
            if (movement.y > 0 && !backwards)
            {
                wheel.collider.brakeTorque = 0;
                ApplyMotorTorque(wheel);
                
            }
            // driving forwards --> brake
            else if (movement.y < 0 && !backwards)
            {
                wheel.collider.motorTorque = 0;
                wheel.collider.brakeTorque = -movement.y * maxAcceleration * 1000000 * Time.deltaTime;
            // driving backwards --> brake
            } else if(movement.y > 0 && backwards)
            {
                wheel.collider.motorTorque = 0;
                wheel.collider.brakeTorque = movement.y * maxAcceleration * 1000000 * Time.deltaTime;
            // driving backwards --> accelerate
            } else if(movement.y < 0 && backwards)
            {
                wheel.collider.brakeTorque = 0;
                ApplyMotorTorque(wheel);
            } else
            {
                wheel.collider.motorTorque = 0;
            }

            // handbrake
            if(handbrake && wheel.axle == Axle.Rear)
            {
                wheel.collider.brakeTorque = maxAcceleration * 2000 * Time.deltaTime;
            }            
        }
    }

    private void CheckDrivingDirection(Rigidbody rigidbody)
    {
        if (rigidbody.velocity.magnitude <= 0.01)
        {
            if (movement.y > 0)
            {
                backwards = false;
            }
            else if (movement.y < 0)
            {
                backwards = true;
            }
        }
    }

    private void ApplyMotorTorque(Wheel wheel)
    {
        if (wheel.collider.attachedRigidbody.velocity.magnitude < maxVelocity)
        {
            wheel.collider.motorTorque = movement.y * maxAcceleration * 500 * Time.deltaTime;
        } else
        {
            wheel.collider.motorTorque = 0;
        }
    }

    private void Turn()
    {
        foreach (Wheel wheel in wheels)
        {
            if(wheel.axle == Axle.Front)
            {
                float steerAngle = movement.x * turnSensitivity * maxSteerAngle;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, steerAngle, 0.5f);
            }
        }
    }

    private void ApplyDownForce()
    {
        if(rb.velocity.magnitude > 30)
        {
            rb.AddForce(Vector3.down * Time.deltaTime * rb.velocity.magnitude * downForce, ForceMode.Force);
        }
    }

    private void AnimateWheels()
    {
        foreach(Wheel wheel in wheels)
        {
            Quaternion wheelRotation;
            Vector3 wheelPosition;
            wheel.collider.GetWorldPose(out wheelPosition, out wheelRotation);
            wheel.model.transform.position = wheelPosition;
            wheelRotation = wheelRotation * Quaternion.Euler(wheelRotationOffset);
            wheel.model.transform.rotation = wheelRotation;
        }
    }

    private void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        print("OnMove: " + movement.x + ", " + movement.y);
    }

    private void OnMoveDpad(InputValue value)
    {
        movement = value.Get<Vector2>();
        print("OnMove Dpad: " + movement.x + ", " + movement.y);
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
        handbrake = true;
    }

    private void OnSouthRelease()
    {
        print("OnSouthRelease");
        handbrake = false;
    }

    private void OnWestPress()
    {
        print("OnWestPress");
    }

    private void OnWestRelease()
    {
        print("OnWestRelease");
    }
}
