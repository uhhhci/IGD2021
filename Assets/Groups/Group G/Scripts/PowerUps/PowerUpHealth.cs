using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHealth : PowerUp
{
    public int HealAmount = 25;

    protected override void PowerUpPayload() 
    {
        base.PowerUpPayload();

        // Payload is to give some health bonus
        Player.GetHealthSystem().Heal(HealAmount);
    }
}
