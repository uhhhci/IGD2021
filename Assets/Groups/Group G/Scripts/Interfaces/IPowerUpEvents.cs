using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IPowerUpEvents : IEventSystemHandler
{
    void OnPowerUpCollected(PowerUp powerUp, Player_G player);

    void OnPowerUpExpired(PowerUp powerUp, Player_G player);
}
