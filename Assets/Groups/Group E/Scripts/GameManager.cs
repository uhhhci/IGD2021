using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int totalWinners;
    public void countRound(GameObject player)
    {
        PlayerStats thePlayer = player.GetComponent<PlayerStats>();
        thePlayer.CountRound();
        Debug.Log("Player " + player.name + " : Round " + thePlayer.rounds);

        if (thePlayer.rounds == 3)
        {
            //player.GetComponent<CarController>().enabled = false;
            //totalWinners += 1;
            Debug.Log("Winner");
        }

    }

    public void nextZone(TriggerZone aCheckpoint)
    {
        
    }

    private void Start()
    {
        totalWinners = 0;
    }
}
