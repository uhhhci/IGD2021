using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpWeapon : PowerUp_G
{
    protected override void PowerUpPayload()
    {
        base.PowerUpPayload();

        PlayerController pc = PlayerController;
        pc.UpdateWeaponByIndex(pc.GetCurrentWeaponIndex() + 1);
    }
}
