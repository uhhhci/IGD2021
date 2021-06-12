using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp
{
    public abstract string Name { get; }
    public abstract IEnumerator UsePowerup(GameObject player);
}
