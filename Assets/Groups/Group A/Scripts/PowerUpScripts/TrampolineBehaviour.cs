﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineBehaviour : MonoBehaviour
{
    public float bounciness = 15f;
    public float secsToDespawn = 15f;
    private void Start()
    {
        Invoke("Despawn", secsToDespawn);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MinifigControllerWTH controller = collision.gameObject.GetComponent<MinifigControllerWTH>();
            Vector3 bounce = new Vector3(0, bounciness, 0);
            controller.AddForce(bounce);
        }

    }
    private void Despawn()
    {
        Destroy(this.gameObject);
    }
}
