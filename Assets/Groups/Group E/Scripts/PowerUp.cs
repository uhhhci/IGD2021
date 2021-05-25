using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    // Could be abstract as well if each pickup should have its own effects
    IEnumerator Pickup(Collider player)
    {
        PlayerStats ps = player.GetComponent<PlayerStats>();
        if(!(ps.hasPowerup))
        {
            ps.power = this;
            ps.hasPowerup = true;
        }

        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(5);

        GetComponent<Collider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;

        //Destroy(gameObject);
    }

    public abstract void UsePowerup();
}
