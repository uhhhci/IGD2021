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
        //Debug.Log("Player " + player.name + " : Round " + thePlayer.rounds);

        if (thePlayer.rounds == 4)
        {
            //player.GetComponent<CarController>().enabled = false;
            //totalWinners += 1;
            Debug.Log("Finished");
        }
    }

    public Transform GetPlayerByPosition(int position)
    {
        // Snapshot of car transform list
        List<Transform> carList = new List<Transform>(carTransformList);

        foreach (Transform car in carList)
        {
            PlayerStats thePlayer = car.GetComponent<PlayerStats>();

            if(thePlayer.GetKartPosition(carList) == position)
            {
                return car;
            }
        }
        
        // Should not be reachable;
        throw new System.Exception("Position Error: The position " + position + " does not exist.");
    }

    public int GetPositionByPlayer(Transform carTransform)
    {
        // Snapshot of car transform list
        List<Transform> carList = new List<Transform>(carTransformList);

        PlayerStats thePlayer = carTransform.GetComponent<PlayerStats>();
        try
        {
            return thePlayer.GetKartPosition(carList);
        }
        catch (System.Exception)
        {
            throw new System.Exception("Position Error: Could not find position of player: " + carTransform.ToString());
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
