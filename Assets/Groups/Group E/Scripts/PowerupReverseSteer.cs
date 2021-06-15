using UnityEngine;
using System.Collections;

public class PowerupReverseSteer : PowerUp
{
    public GameManager_E gameManager;
    public int DURATION = 10;

    public PowerupReverseSteer(GameManager_E gameManager_e)
    {
        gameManager = gameManager_e;
    }

    public override string Name { get { return "ReverseSteer"; } }
    public override IEnumerator UsePowerup(GameObject player)
    {
        int activatorPosition = gameManager.GetPositionByPlayer(player.GetComponent<Transform>());

        int targetPosition = activatorPosition - 1;
        if (targetPosition == 0) { targetPosition = 2; }

        Transform targetPlayer = gameManager.GetPlayerByPosition(targetPosition);

        PlayerStats ps = player.GetComponent<PlayerStats>();
        ps.UsedPowerup();

        CarController targetCarController = targetPlayer.GetComponent<CarController>();

        PlayerStats tps = targetPlayer.GetComponent<PlayerStats>();
        if(!tps.hasShield)
        {
            targetCarController.steeringReversed = true;
            tps.hasShield = false;
        }

        yield return new WaitForSeconds(DURATION);

        targetCarController.steeringReversed = false;
    }

}
