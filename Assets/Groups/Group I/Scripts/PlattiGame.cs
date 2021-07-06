using UnityEngine;
using System.Collections.Generic;

public class PlattiGame : MiniGame
{
    public List<playercollision> players;

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
        testelele();
    }

    void Update()
    {

    }

    public void testelele()
    {
        float pos = players[0].getZPos();
        Debug.Log("z pos 0: " + pos);
    }
}
