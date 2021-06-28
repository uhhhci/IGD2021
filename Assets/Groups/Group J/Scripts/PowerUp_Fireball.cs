using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Fireball : MonoBehaviour
{
    public int FireballCount = 5;

    public void RemovePowerUp(MinifigControllerJ controller)
    {

        Debug.Log("Removed fireball");
    }

    public IEnumerator ApplyPowerUp(MinifigControllerJ controller)
    {
        Debug.Log("ApplyFireball");
        yield return FireballCount > 0 ? true : false;
        RemovePowerUp(controller);

    }
}
