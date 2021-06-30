
using System;
using UnityEngine;

public class playercollision : MonoBehaviour
{
    MinifigController player;
    public AudioSource playSoundGravity;
    public AudioSource playSoundSpeed;

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
            playSoundGravity.Play();
        }

        if (pickup.tag == "HighSpeed")
        {
            PickUp(pickup);
            player.maxForwardSpeed *= 2;
            playSoundSpeed.Play();
        }

        
    }

    private void PickUp(GameObject pickup)
    {
        Debug.Log("Picked up: " + pickup.tag);
        Destroy(pickup);
    }
}
