using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Shield : MonoBehaviour
{
    private float secondsToUse = 10;
    public void RemovePowerUp(MinifigControllerJ controller)
    {
     
        Debug.Log("Removed shied");
    }

    public IEnumerator ApplyPowerUp(GameObject shieldPrefab,MinifigControllerJ controller)
    {
        //player.getcomponent.punchable = false??
        // und wenn einmal gepunched dann shild zerstören?
        CreateShield(shieldPrefab,controller);
        yield return new WaitForSeconds(secondsToUse);
        Destroy(shieldPrefab);

    }

    GameObject CreateShield(GameObject shieldPrefab, MinifigControllerJ player)
    {
        var projectileObj = Instantiate(shieldPrefab,new Vector3(player.transform.position.x, player.transform.position.y+1, player.transform.position.z), Quaternion.identity) as GameObject;
        projectileObj.transform.SetParent(player.transform);
        return projectileObj;
    }
}
