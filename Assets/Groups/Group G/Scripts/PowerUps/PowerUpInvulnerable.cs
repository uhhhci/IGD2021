using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvulnerable : PowerUp_G
{
    public float Duration = 5f;
    public GameObject InvulnParticles;
    private GameObject InvulnParticlesInstance;

    protected override void PowerUpPayload()
    {
        base.PowerUpPayload();
        Player.SetInvulnerability(true);
        if (InvulnParticles != null)
        {
            InvulnParticlesInstance = Instantiate(InvulnParticles, Player.gameObject.transform.position, Player.gameObject.transform.rotation, transform);
        }
    }

    protected override void PowerUpHasExpired()
    {
        if (State == PowerUpState.IsExpiring)
        {
            return;
        }
        Player.SetInvulnerability(false);
        if (InvulnParticlesInstance != null)
        {
            Destroy(InvulnParticlesInstance);
        }
        base.PowerUpHasExpired();
    }

    private void Update()
    {
        if (State == PowerUpState.IsCollected)
        {
            Duration -= Time.deltaTime;
            if (Duration < 0)
            {
                PowerUpHasExpired();
            }
        }
    }
}
