using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoPaperScissorsMinigame : MiniGame
{
    public override string getDisplayName()
    {
        return "LegoPaperScissors";
    }

    public override MiniGameType getMiniGameType()
    {
        return MiniGameType.teamVsTeam;
    }

    public override string getSceneName()
    {
        return "Main";
    }

    public void MinigameFinished()
    {
        // TODO if phase == phase.end (from PhaseHandler), set first int[] first place, ..... 
    }

    // Start is called before the first frame update
    void Start()
    {
     // TODO assignPlayerInput   
    }
}
