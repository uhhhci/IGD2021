using UnityEngine;
using System.Collections;

public class PowerupSpeed : PowerUp
{
    public override string Name { get { return "Speed"; } }
    private static int DURATION = 5;
    private static int MULTIPLIER = 2;
    private static int BRICKPOWER = 25;
    public override IEnumerator UsePowerup(GameObject player)
    {
        Debug.Log("Name: " + Name);

        CarController controller = player.GetComponent<CarController>();
        PlayerStats ps = player.GetComponent<PlayerStats>();
        bool usedBrick = false;
        if(ps.hasWhiteBrick)
        {
            usedBrick = true;
            controller.maxVelocity += BRICKPOWER;
            controller.maxAcceleration += BRICKPOWER;
        }

        controller.maxVelocity = MULTIPLIER;
        controller.maxAcceleration *= MULTIPLIER;

        ps.UsedPowerup();

        yield return new WaitForSeconds(DURATION);

        controller.maxVelocity /= MULTIPLIER;
        controller.maxAcceleration /= MULTIPLIER;

        if (usedBrick)
        {
            controller.maxVelocity -= BRICKPOWER;
            controller.maxAcceleration -= BRICKPOWER;
        }
    }

}
