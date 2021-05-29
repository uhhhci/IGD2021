using UnityEngine;

public class PowerupSpeed : PowerUp
{
    public override string Name { get { return "Speed"; } }
    public override void UsePowerup(Collider player)
    {
        Debug.Log("Name: " + Name);

        PlayerStats ps = player.GetComponent<PlayerStats>();
        ps.hasPowerup = false;
        ps.power = null;

        CarController controller = player.GetComponent<CarController>();
        controller.maxVelocity *= 2;
        controller.maxAcceleration *= 2;
    }

}
