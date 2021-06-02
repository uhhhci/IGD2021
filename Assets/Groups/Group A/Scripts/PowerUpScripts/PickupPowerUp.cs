using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPowerUp : MonoBehaviour
{
    public BasePowerUp powerUp { get; set; }
    public float secsToDespawn = 15f;
    private void Awake()
    {
        powerUp = new TrampolinePowerUp();
    }

    private void Start()
    {
        Invoke("Despawn", secsToDespawn);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MinifigControllerWTH controller = collision.gameObject.GetComponent<MinifigControllerWTH>();
            controller.AddPowerUp(powerUp);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "floor")
        {
            Destroy(this.gameObject);
        }

    }

    private void Despawn()
    {
        Destroy(this.gameObject);
    }

}
