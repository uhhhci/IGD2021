using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossTheCanyons : MiniGame
{
    public void GameOver(int leftPlayerFinalLevel, int rightPlayerFinalLevel)
    {
        int[] firstPlace;
        int[] secondPlace;
        if (leftPlayerFinalLevel > rightPlayerFinalLevel)
        {
            firstPlace = new int[] {0,1};
            secondPlace = new int[] {2,3};
        }
        else if (rightPlayerFinalLevel > leftPlayerFinalLevel)
        {
            firstPlace = new int[] {2,3};
            secondPlace = new int[] {0,1};
        }
        else
        {
            firstPlace = new int[] {0,1,2,3};
            secondPlace = new int[] {};
        }
        MiniGameFinished(firstPlace, secondPlace, new int[] {}, new int[] {});
    }

    public override string getDisplayName()
    {
        return "Cross the Canyons";
    }
    public override string getSceneName()
    {
        return "CrossTheCanyons";
    }

    public override MiniGameType getMiniGameType()
    {
        return MiniGameType.teamVsTeam;
    }
}
