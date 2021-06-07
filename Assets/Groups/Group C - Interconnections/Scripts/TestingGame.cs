using UnityEngine;

public class TestingGame : MiniGame
{
   

    public override string getDisplayName(){
        return "Game  Title";
    }
    public override string getSceneName(){
        return "Example";
    }

    public override MiniGameType getMiniGameType()
    {
        return MiniGameType.freeForAll;
    }

    void Start()
    {   
        PlayerPrefs.SetString("PLAYER1_NAME", "Brenda");
        PlayerPrefs.SetString("PLAYER2_NAME", "Jovanna");
        PlayerPrefs.SetString("PLAYER3_NAME", "Myriem");
        PlayerPrefs.SetString("PLAYER4_NAME", "Jose");

        //base.MiniGameFinished(new int []{1,2}, new int []{3,4}, new int []{},new int []{});
        //base.MiniGameFinished(new int []{3,2,4}, new int []{1}, new int []{},new int []{});
        base.MiniGameFinished(new int []{2}, new int []{4}, new int []{1},new int []{3});
        Debug.Log(PlayerPrefs.GetInt("PLAYER1_PLACE"));
        Debug.Log(PlayerPrefs.GetInt("PLAYER2_PLACE"));
        Debug.Log(PlayerPrefs.GetInt("PLAYER3_PLACE"));
        Debug.Log(PlayerPrefs.GetInt("PLAYER4_PLACE"));
    }
}