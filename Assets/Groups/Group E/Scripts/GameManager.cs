using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int totalWinners;
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
        
    }
}
