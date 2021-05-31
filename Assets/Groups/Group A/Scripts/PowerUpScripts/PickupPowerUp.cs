using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPowerUp : MonoBehaviour
{
    public BasePowerUp powerUp { get; set; }
    private void Awake()
    {
        powerUp = new TrampolinePowerUp();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MinifigControllerWTH controller = collision.gameObject.GetComponent<MinifigControllerWTH>();
            controller.AddPowerUp(powerUp);
            Destroy(this.gameObject);
        }

    }
}
