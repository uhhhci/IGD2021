using System.Collections;
using UnityEngine;

public class PowerupItem : MonoBehaviour
{
    PowerUp[] powerupsArr = { (new PowerupShield()), (new PowerupSpeed())};
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    public IEnumerator Pickup(Collider player)
    {
        int rnd = Random.Range(0, powerupsArr.Length);
        PowerUp powerup = powerupsArr[rnd];

        PlayerStats ps = player.GetComponent<PlayerStats>();
        if (!(ps.hasPowerup))
        {
            // Variable assignment doesn't work
            ps.power = powerup;
            Debug.Log(ps.power);
            ps.hasPowerup = true;
            ps.textPowerup.text = "Powerup: " + powerup.Name;
        }

        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(5);

        GetComponent<Collider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
        
        powerup.UsePowerup(player);
    }
}
