using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatPowerUp : BasePowerUp
{
    public BatPowerUp()
    {
        this.Identifier = "BaseballBat";
    }
    public override void SpawnPowerUp(Vector3 playerPosition)
    {
        Vector3 position = playerPosition;
        SpawnPowerUps.instance.SpawnPowerUp(Identifier, position, Quaternion.Euler(0, 0, 0));
    }
}
