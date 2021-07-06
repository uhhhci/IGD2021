using UnityEngine;
using System.Collections.Generic;

public class PlattiGame : MiniGame
{
    public List<GameObject> players;

    public override string getDisplayName()
    {
        return "RunBrickRun";
    }

    public override MiniGameType getMiniGameType()
    {
        return MiniGameType.freeForAll;
    }

    public override string getSceneName()
    {
        return "RunBrickRun";
    }

    void Start()
    {
        List<int> playerIds = new List<int> { 1, 2, 3, 4 };
        // Comment in for global testing
        //InitializePlayers(players, playerIds);

        testelele();
    }

    void Update()
    {

    }

    public void testelele()
    {
        float pos = ((playercollision) players[0].GetComponent("playercollision")).getZPos();
        Debug.Log("z pos 0: " + pos);
    }
}
