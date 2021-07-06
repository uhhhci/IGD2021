using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InterconnectionsAi : MonoBehaviour
{
    List<PlayerProperties> players;

    public bool IsAiPlayer(string playerName)
    {
        // print($"InterconnectionsAi was asked for IsAiPlayer with playerName: {playerName}");
        // goes through all players in the order which is also used to get the input,
        // such that we know which player is the first, second and so on
        // then searches for the correct string variable set by the interconnections group

        try
        {
            for (int index = 1; index <= 4; index++)
            {
                var player = players[index - 1];

                if (playerName == player.playerName)
                {
                    bool isAi = PlayerPrefs.GetString($"PLAYER{index}_AI").Equals("True");
                    // print($"player at index {index} ({playerName}) isAi? {isAi}");
                    return isAi;
                }
            }

            print($"could not find matching player for name {playerName} while calling IsAiPlayer");
            return false;
        }

        catch(Exception e)
        {
            // ugly ik, but I could not find out why this fails for the first time its called
            // probably a faulty initialization order, but there is no time left for debugging
            // so I decided to just catch this, gets called every frame anyways
            print("expected first call failure in IsAiPlayer");
            return false;
        }
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
