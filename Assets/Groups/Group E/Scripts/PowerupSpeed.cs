using UnityEngine;
using System.Collections;

public class PowerupSpeed : PowerUp
{
    public override string Name { get { return "Speed"; } }
    public override IEnumerator UsePowerup(GameObject player)
    {
        Debug.Log("Name: " + Name);

        CarController controller = player.GetComponent<CarController>();
        PlayerStats ps = player.GetComponent<PlayerStats>();
        bool usedBrick = false;
        if(ps.hasWhiteBrick)
        {
            usedBrick = true;
            controller.maxVelocity += 30;
            controller.maxAcceleration += 30;
        }

        controller.maxVelocity *= 2;
        controller.maxAcceleration *= 2;

        ps.UsedPowerup();

        yield return new WaitForSeconds(5);

        controller.maxVelocity /= 2;
        controller.maxAcceleration /= 2;

        if (usedBrick)
        {
            controller.maxVelocity -= 30;
            controller.maxAcceleration -= 30;
        }
    }

}
