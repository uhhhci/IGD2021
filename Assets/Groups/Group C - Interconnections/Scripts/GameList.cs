
using System.Collections.Generic;

public static class GameList
{
    public static List<string> GAMES = new List<string> {"Free for All","One vs Three","Two vs Two"};

    //Board Group: change the name of the scene if required
    public const string MAIN_BOARD_SCENE = "BoardScene";

    public static List<MiniGame> FREE_FOR_ALL_LIST = new List<MiniGame>{
        new TestingGame(),
        new TestingGame(),
        new TestingGame(),
        new KartRacingGame()
    };

    public static List<MiniGame> SINGLE_VS_TEAM_LIST = new List<MiniGame>{
        new TestingGame(),
        new TestingGame(),
        new TestingGame()
    };

    public static List<MiniGame> TEAM_VS_TEAM_LIST = new List<MiniGame>{
        new TestingGame(),
        new TestingGame(),
        new TestingGame()
    };

}



