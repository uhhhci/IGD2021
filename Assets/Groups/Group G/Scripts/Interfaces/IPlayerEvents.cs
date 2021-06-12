using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

/// <summary>
/// Inteface defining messages sent by the player
/// </summary>
public interface IPlayerEvents : IEventSystemHandler
{
    void OnPlayerHurt(int newHealth);

}
