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
        if(players.Count == 4)
        {
            for (int index = 1; index <= 4; index++)
            {
                var player = players[index - 1];
                // print($"player name: {player.playerName}");

                if (playerName == player.playerName)
                {
                    bool isAi = PlayerPrefs.GetString($"PLAYER{index}_AI").Equals("True");
                    // print($"player at index {index} ({playerName}) isAi? {isAi}");
                    return isAi;
                }
            }

            return false;
        }

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        players = PhaseHandler.players;
    }

    // Update is called once per frame
    void Update()
    {
        players = PhaseHandler.players;
    }
}
