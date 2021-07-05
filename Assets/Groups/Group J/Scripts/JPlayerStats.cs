using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPlayerStats : MonoBehaviour
{
    public MinifigControllerJ player;
    PowerUp_Speed powerUpSpeed;
    PowerUp_Fireball powerUpFireball;
    public int fireballCount = 0;
   
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
                break;
            case PowerUpType.Fireball:
                Debug.Log("Add Fireballs");
                powerUpFireball = new PowerUp_Fireball();
                powerUpFireball.ApplyPowerUp(player);
                break;
            default:
                break;
        }
    }
}
