
using System;
using UnityEngine;
using UnityEngine.UI;

public class playercollision : MonoBehaviour
{
    MinifigController player;
    public AudioSource playSoundGravity;
    public AudioSource playSoundSpeed;
    public int currentHealth = 100;

    private void Start()
    {
        player = (MinifigController)this.GetComponent("MinifigController");
        //HealtSystem of Player 
        HealthSystemI healthSystem = new HealthSystemI(100);
        currentHealth = 100;
    }

    public void HealthUp()
    {
        HealthSystemI healthSystem = new HealthSystemI(currentHealth);
        healthSystem.Heal(10);
        currentHealth = healthSystem.GetHealth2();
        Debug.Log("Health" + healthSystem.GetHealth2());
    }

    public void HealthDown()
    {
        HealthSystemI healthSystem = new HealthSystemI(currentHealth);
        healthSystem.Damage(10);
        currentHealth = healthSystem.GetHealth2();
        Debug.Log("Health" + healthSystem.GetHealth2());
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

        if (pickup.tag == "PlusLife")
        {
            PickUp(pickup);
            HealthUp();
            playSoundSpeed.Play();
        }

        if (pickup.tag == "Respawn")
        {
            
            HealthDown();
            playSoundSpeed.Play();
        }


    }

    private void PickUp(GameObject pickup)
    {
        Debug.Log("Picked up: " + pickup.tag);
        Destroy(pickup);
    }
}
