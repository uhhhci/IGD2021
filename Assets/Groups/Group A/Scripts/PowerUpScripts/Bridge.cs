using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  BridgePowerUp : BasePowerUp
{
    public BridgePowerUp()
    {
        this.Identifier = "Bridge";
    }

    public override void SpawnPowerUp(Vector3 playerPosition)
    {
        Vector3 position = playerPosition;
        Vector3 direction = new Vector3(0, playerPosition.y, 0) - playerPosition;
        // float angle = Vector3.Angle(direction, new Vector3(1, 0, 0));
        Quaternion quaternion = Quaternion.LookRotation(direction) * Quaternion.Euler(0,90,0);
        SpawnPowerUps.instance.SpawnPowerUp(Identifier, position, quaternion);
    }
}
