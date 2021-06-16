using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PowerUpSpeed : PowerUp_G, IPlayerEvents
{
    [Range(1.0f, 4.0f)]
    public float speedMultiplier = 2.0f;

    protected override void PowerUpPayload()         
    {
        base.PowerUpPayload();
        PlayerController.SetSpeedBoostOn(speedMultiplier);
    }

    protected override void PowerUpHasExpired()       
    {
        PlayerController.SetSpeedBoostOff();
        base.PowerUpHasExpired();
    }

    void IPlayerEvents.OnPlayerHurt(int newHealth)
    {
        if (State != PowerUpState.IsCollected)
        {
            return;
        }

        PowerUpHasExpired();
    }
}
