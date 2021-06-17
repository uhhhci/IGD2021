
using System;
using UnityEngine;

public class playercollision : MonoBehaviour
{
    MinifigController player;

    private void Start()
    {
        player = (MinifigController)this.GetComponent("MinifigController");
    }

    void OnTriggerEnter(Collider col)
    {
        GameObject pickup = col.gameObject;

        if (pickup.tag == "ItemCollect")
        {
            PickUp(pickup);
        }

        if (pickup.tag == "LowGravity")
        {
            PickUp(pickup);
            player.gravity /= 2;
        }

        if (pickup.tag == "HighSpeed")
        {
            PickUp(pickup);
            player.maxForwardSpeed *= 2;
        }

        if (pickup.tag == "HighSpeed")
        {
            PickUp(pickup);
            player.maxForwardSpeed *= 2;
        }
    }

    private void PickUp(GameObject pickup)
    {
        Debug.Log("Picked up: " + pickup.tag);
        Destroy(pickup);
    }
}
