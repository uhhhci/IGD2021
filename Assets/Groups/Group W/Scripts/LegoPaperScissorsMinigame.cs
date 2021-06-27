using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class LegoPaperScissorsMinigame : MiniGame
{
    List<PlayerInput> playerInputs;
    List<PlayerProperties> players;
    public static PhaseHandler.Phase phase;

    public override string getDisplayName() => "LegoPaperScissors";

    public override MiniGameType getMiniGameType() => MiniGameType.teamVsTeam;

    public override string getSceneName() => "LegoPaperScissors";

    public void GetWinners()
    {
        if (phase == PhaseHandler.Phase.End)
        {
            print("end phase!");
            PhaseHandler.Team leadingTeam = PhaseHandler.leadingTeam;

            int[] firstPlaceIndices = players.Select((v, i) => new { v, i })
                    .Where(x => x.v.team == leadingTeam)
                    .Select(x => x.i).ToArray();


            int[] secondPlaceIndices = players.Select((v, i) => new { v, i })
                    .Where(x => x.v.team != leadingTeam)
                    .Select(x => x.i).ToArray();

            // since this is a teamVsTeam game, there are no 3rd/4th places
            MiniGameFinished(firstPlace: firstPlaceIndices, secondPlace: secondPlaceIndices, thirdPlace: new int[] { }, fourthPlace: new int[] { });
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        phase = PhaseHandler.phase;
        players = PhaseHandler.players;
        GetWinners();
    }
}
