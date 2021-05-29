using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public abstract string Name { get; }
    public abstract void UsePowerup(Collider player);
}
