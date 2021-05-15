using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int totalWinners;
    public void countRound(GameObject player)
    {
        PlayerStats thePlayer = player.GetComponent<PlayerStats>();
        thePlayer.rounds += 1;
        Debug.Log("Player " + player.name + " : Round " + thePlayer.rounds);

        if (thePlayer.rounds == 3)
        {
            player.GetComponent<MinifigController>().enabled = false;
            //totalWinners += 1;
            Debug.Log("Winner");
        }

    }
    private void Start()
    {
        totalWinners = 0;
    }
}
