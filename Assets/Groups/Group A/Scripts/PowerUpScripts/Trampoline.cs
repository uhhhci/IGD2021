using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolinePowerUp : BasePowerUp
{
    public TrampolinePowerUp()
    {
        this.Identifier = "Trampoline";
    }
    public override void SpawnPowerUp(Vector3 playerPosition)
    {
        Vector3 position = playerPosition;
        SpawnPowerUps.instance.SpawnPowerUp(Identifier, position, Quaternion.Euler(0, 0, 0));
    }
}

