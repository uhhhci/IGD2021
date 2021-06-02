using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePowerUp
{
    public string Identifier;
    public virtual void SpawnPowerUp(Vector3 position) { return; }
}
