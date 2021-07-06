using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterconnectionsAi : MonoBehaviour
{
    List<PlayerProperties> players;

    public bool IsAiPlayer(string playerName)
    {
        // goes through all players in the order which is also used to get the input,
        // such that we know which player is the first, second and so on
        // then searches for the correct string variable set by the interconnections group
        for (int index = 1; index <= 4; index++)
        {
            var player = players[index -1];

            // TODO this is just for demo purposes and should be removed after presentation
            if(playerName == "PLÖÄ")
            {
                // print("demo! PLÖÄ is an AI now");
                return true;
            }

            if(playerName == player.playerName)
            {
                bool isAi = PlayerPrefs.GetString($"Player{index}_AI").Equals("True");
                // print($"player at index {index} ({playerName}) isAi? {isAi}");
                return isAi;
            }
        }

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        players = PhaseHandler.players;
    }
}
