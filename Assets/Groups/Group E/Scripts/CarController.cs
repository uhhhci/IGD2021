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
    private bool controlEnabled = true;

    public float maxAcceleration = 20.0f;
    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 45.0f;
    public float maxVelocity = 30.0f;
    public List<Wheel> wheels;
    public Vector3 centerOfMass;
    public Vector3 wheelRotationOffset;
    public float downForce = 10.0f;
    public List<GameObject> fastGrounds;
    public Boolean steeringReversed = false;

    public void DisableControl()
    {
        controlEnabled = false;
    }

    void FixedUpdate()
    {
        CheckDrivingDirection(rb);
        ChangeGroundDependentSpeed();
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

    private void ChangeGroundDependentSpeed()
    {

        RaycastHit raycastHit;
        Vector3 raycastStart = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        if (Physics.Raycast(raycastStart, Vector3.down, out raycastHit, 40.0f))
        {
            if(fastGrounds.Contains(raycastHit.collider.gameObject))
            {
                SetWheelsStiffnessTo(2.0f);
            } else
            {
                SetWheelsStiffnessTo(0.4f);
            }
        }
    }

    private void SetWheelsStiffnessTo(float stiffness)
    {
        foreach (Wheel wheel in wheels)
        {
            SetWheelStiffnessTo(wheel, stiffness);
        }
    }

    private void SetWheelStiffnessTo(Wheel wheel, float stiffness)
    {
        WheelFrictionCurve forwardFriction = wheel.collider.forwardFriction;
        forwardFriction.stiffness = stiffness;
        wheel.collider.forwardFriction = forwardFriction;
        WheelFrictionCurve sidewaysFriction = wheel.collider.sidewaysFriction;
        sidewaysFriction.stiffness = stiffness;
        wheel.collider.sidewaysFriction = sidewaysFriction;
    }

    private void Move()
    {
        foreach (Wheel wheel in wheels)
        {
            if (controlEnabled)
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
                    ApplyBrakeTorque(wheel, -movement.y);
                // driving backwards --> brake
                }
                else if (movement.y > 0 && backwards)
                {
                    wheel.collider.motorTorque = 0;
                    ApplyBrakeTorque(wheel, movement.y);
                // driving backwards --> accelerate
                }
                else if (movement.y < 0 && backwards)
                {
                    wheel.collider.brakeTorque = 0;
                    ApplyMotorTorque(wheel);
                }
                else
                {
                    wheel.collider.motorTorque = 0;
                }

                // handbrake
                if (handbrake && wheel.axle == Axle.Rear)
                {
                    wheel.collider.brakeTorque = maxAcceleration * 2000 * Time.deltaTime;
                }
            } else
            {
                wheel.collider.motorTorque = 0;
                wheel.collider.brakeTorque = maxAcceleration * 35 * Time.deltaTime;
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
        }
        else
        {
            wheel.collider.motorTorque = 0;
        }
    }

    private void ApplyBrakeTorque(Wheel wheel, float direction)
    {
        wheel.collider.brakeTorque = direction * maxAcceleration * 1000000  * Time.deltaTime;
    }

    private void Turn()
    {
        if(controlEnabled)
        {
            foreach (Wheel wheel in wheels)
            {
                if (wheel.axle == Axle.Front)
                {
                    float steerAngle = movement.x * turnSensitivity * maxSteerAngle;
                    if(steeringReversed)
                    {
                        steerAngle = -steerAngle;
                    }
                    wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, steerAngle, 0.5f);
                }
            }
        }
    }

    private void ApplyDownForce()
    {
        if (rb.velocity.magnitude > 30)
        {
            rb.AddForce(Vector3.down * Time.deltaTime * rb.velocity.magnitude * downForce, ForceMode.Force);
        }
    }

    private void AnimateWheels()
    {
        foreach (Wheel wheel in wheels)
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
    }

    private void OnMoveDpad(InputValue value)
    {
        Debug.Log("onmovedpad: " + movement);
        movement = value.Get<Vector2>();
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
        //print("Powerup");
        PlayerStats ps = gameObject.GetComponent<PlayerStats>();
        if(ps.hasPowerup)
        {
            StartCoroutine(ps.power.UsePowerup(ps.gameObject));
        }
    }

    private void OnEastRelease()
    {
        //print("OnEastRelease");
    }

    private void OnSouthPress()
    {
        handbrake = true;
    }

    private void OnSouthRelease()
    {
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
