﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.enabled = false;
        Debug.Log("Coll");
        if (other.tag == ("Player"))
        {
            other.enabled = true;
            Debug.Log("PickUp");
            PickUp(other);
           
        }
        else
        {
            other.enabled = false;
        }
    }

    void PickUp(Collider player)
    {
        MinifigControllerJ controller = player.GetComponent<MinifigControllerJ>();
        controller.maxForwardSpeed *= 2;
        controller.acceleration *= 2;
        Destroy(this.gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Obstacle"))
        {
            Physics.IgnoreLayerCollision(gameObject.layer, 21, true);
        }

     
    }

    IEnumerator ActivateInvincibility()
    {
        Physics.IgnoreLayerCollision(gameObject.layer, 21, true);


        yield return new WaitForSeconds(3);

        Physics.IgnoreLayerCollision(gameObject.layer, 21, false);
    }
}
