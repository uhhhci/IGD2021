using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPlayerStats : MonoBehaviour
{
    public MinifigControllerJ player;
    PowerUp_Speed powerUpSpeed;
    PowerUp_Fireball powerUpFireball;
   
    private void Update()
    {
        
    }
    public void AddPowerUp(PowerUpType type)
    {
        switch (type)
        {
            case PowerUpType.Speed:
                powerUpSpeed = new PowerUp_Speed();
               StartCoroutine( powerUpSpeed.ApplyPowerUp(player));
                break;
            case PowerUpType.Shield:
                powerUpFireball = new PowerUp_Fireball();
                StartCoroutine(powerUpFireball.ApplyPowerUp(player));
                break;
            case PowerUpType.Fireball:
                break;
            default:
                break;
        }
    }
}
