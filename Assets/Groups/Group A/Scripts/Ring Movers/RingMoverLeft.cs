using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMoverLeft : MonoBehaviour
{
    public float rotation_speed, t, s;
    // Start is called before the first frame update
    void Start()
    {
        rotation_speed = 1f;
        s = -5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (s <= (Time.time - 5f)) t = Time.time;
    }

    private void OnTriggerExit(Collider other)
    {
        s = Time.time;
        t = 0f;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            float r = Time.time;
            if (r <= (t + 5f) && r >= (s + 5f))
            {
                GenerateRings.instance.RotateRing(1, rotation_speed);
            }
            Debug.Log(other);
        }

    }
}
