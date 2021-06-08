using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficTrouble : MiniGame
{ 
    override public string getDisplayName()
    {
        return "TrafficTrouble";
    }

    override public string getSceneName()
    {
        return "TrafficTrouble";
    }

    override public MiniGameType getMiniGameType()
    {
        return MiniGameType.freeForAll;
    }

    public void SubmitHealth()
    {

    }

    public void TimeIsOver()
    {
        // TODO get ranking
        int[] firstPlace = null;
        int[] secondPlace = null;
        int[] thirdPlace = null;
        int[] fourthPlace = null;

        MiniGameFinished(firstPlace, secondPlace, thirdPlace, fourthPlace);
    }


}
