using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShrink : PowerUp_G
{
    public float Duration = 5f;
    [Range(1.0f, 2.0f)]
    public float Dividor = 1.7f;

    protected override void PowerUpPayload()
    {
        base.PowerUpPayload();
        PlayerController.transform.localScale /= Dividor;
        StartCoroutine(WaitUntilExpires());
    }

    protected override void PowerUpHasExpired()
    {
        PlayerController.transform.localScale *= Dividor;
        base.PowerUpHasExpired();
    }

    IEnumerator WaitUntilExpires()
    {
        yield return new WaitForSeconds(Duration);
        PowerUpHasExpired();
    }
}
