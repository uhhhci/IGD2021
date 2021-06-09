using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IPowerUpEvents : IEventSystemHandler
{
    void OnPowerUpCollected(PowerUp_G powerUp, Player_G player);

    void OnPowerUpExpired(PowerUp_G powerUp, Player_G player);
}
