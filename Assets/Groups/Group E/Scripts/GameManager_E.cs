using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager_E : MonoBehaviour
{
    int totalWinners;
    public List<Transform> carTransformList;
    public List<Transform> carPositionList;
    public void countRound(Transform player)
    {
        PlayerStats thePlayer = player.GetComponent<PlayerStats>();
        thePlayer.CountRound();
        Debug.Log("Player " + player.name + " : Round " + thePlayer.rounds);

        if (thePlayer.rounds == 4)
        {
            //player.GetComponent<CarController>().enabled = false;
            //totalWinners += 1;
            Debug.Log("Finished");
        }
    }
    private void Start()
    {
        totalWinners = 0;

    }

    private void Update()
    {
        foreach (Transform car in carTransformList)
        {
            PlayerStats thePlayer = car.GetComponent<PlayerStats>();
            thePlayer.GetKartPosition(carTransformList);
            
            // some error
            //carPositionList[thePlayer.GetKartPosition(carTransformList)] = car;
        }
    }
}
