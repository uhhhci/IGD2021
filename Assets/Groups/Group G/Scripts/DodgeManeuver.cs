using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeManeuver : MonoBehaviour
{
    public float Dodge;
    public float Smoothing;
    public float Tilt;
    public Vector2 StartWait;
    public Vector2 ManeuverTime;
    public Vector2 ManeuverWait;
    public Boundary Boundary;

    private float CurrentSpeed;
    private float TargetManeuver;
    private Rigidbody Rb;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        CurrentSpeed = Rb.velocity.z;
        StartCoroutine(Dodging());
    }

    IEnumerator Dodging()
    {
        yield return new WaitForSeconds(Random.Range(StartWait.x, StartWait.y));

        while (true)
        {
            TargetManeuver = Random.Range(1, Dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(ManeuverTime.x, ManeuverTime.y));
            TargetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(ManeuverWait.x, ManeuverWait.y));
        }
    }

    void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(Rb.velocity.x, TargetManeuver, Time.deltaTime * Smoothing);
        Rb.velocity = new Vector3(newManeuver, 0.0f, CurrentSpeed);
        Rb.position = new Vector3
        (
            Mathf.Clamp(Rb.position.x, Boundary.xMin, Boundary.xMax),
            0.0f,
            Mathf.Clamp(Rb.position.z, Boundary.zMin, Boundary.zMax)
        );

        Rb.rotation = Quaternion.Euler(0.0f, 0.0f, Rb.velocity.x * -Tilt);
    }
}
