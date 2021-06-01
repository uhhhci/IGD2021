using UnityEngine;
using System.Collections;

public class PowerupSpeed : PowerUp
{
    public override string Name { get { return "Speed"; } }
    public override IEnumerator UsePowerup(GameObject player)
    {
        Debug.Log("Name: " + Name);

        CarController controller = player.GetComponent<CarController>();
        controller.maxVelocity *= 2;
        controller.maxAcceleration *= 2;

        PlayerStats ps = player.GetComponent<PlayerStats>();
        ps.UsedPowerup();

        yield return new WaitForSeconds(5);

        controller.maxVelocity /= 2;
        controller.maxAcceleration /= 2;
    }

}
