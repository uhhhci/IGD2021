using UnityEngine;
using System.Collections;

public class PowerupAttack : PowerUp {

    private MissileManager missileManager;

    public PowerupAttack(MissileManager missileManager)
    {
        this.missileManager = missileManager;
    }

    public override string Name { get { return "Attack"; } }
    public override IEnumerator UsePowerup(GameObject player)
    {
        Debug.Log("Name: " + Name);

        CarController controller = player.GetComponent<CarController>();
        PlayerStats ps = player.GetComponent<PlayerStats>();
        bool usedBrick = false;
        if(ps.hasGoldenBrick)
        {
            usedBrick = true;
     
        }
        // apply powerup actions
        Missile missile = missileManager.CreateMissile(player.transform);
        missile.Shoot();

        ps.UsedPowerup();

        yield return new WaitForSeconds(15);

        // undo actions

        // if not already destroyed
        if(missile != null)
        {
            missile.Destroy();
        }
        

        if (usedBrick)
        {
          
        }
    }

}
