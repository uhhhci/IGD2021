using UnityEngine;
using System.Collections;

public class PowerupShield : PowerUp
{
    public override string Name { get { return "Shield"; } }
    public override IEnumerator UsePowerup(GameObject player)
    {
        Debug.Log("Name: " + Name);

        PlayerStats ps = player.GetComponent<PlayerStats>();
        ps.UsedPowerup();

        yield return new WaitForSeconds(5);
    }

}
