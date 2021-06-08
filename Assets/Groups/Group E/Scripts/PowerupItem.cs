using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupItem : MonoBehaviour
{
    public GameManager_E gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    public IEnumerator Pickup(Collider player)
    {
        PowerUp[] powerupsArr = { new PowerupShield(), new PowerupSpeed(), new PowerupReverseSteer(gameManager) };
        //PowerUp[] powerupsArr = { new PowerupReverseSteer(gameManager) };

        int rnd = Random.Range(0, powerupsArr.Length);
        PowerUp powerup = powerupsArr[rnd];

        PlayerStats ps = player.GetComponent<PlayerStats>();
        if (!(ps.hasPowerup))
        {
            ps.power = powerup;
            ps.hasPowerup = true;
            ps.textPowerup.text = "Powerup: \n" + powerup.Name;
        }

        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(5);

        GetComponent<Collider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
    }
}
