using UnityEngine;

public class PowerupShield : PowerUp
{
    public override string Name { get { return "Shield"; } }
    public override void UsePowerup(Collider player)
    {
        Debug.Log("Name: " + Name);

        PlayerStats ps = player.GetComponent<PlayerStats>();
        ps.hasPowerup = false;
        ps.power = null;
    }

}
