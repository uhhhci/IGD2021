
using System.Collections.Generic;

public static class GameList
{
    public static List<string> GAMES = new List<string> {"Free for All","One vs Three","Two vs Two"};
    public static List<MiniGame> FREE_FOR_ALL_LIST = new List<MiniGame>{
        new TestingGame(),
        new TestingGame(),
        new TestingGame()
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



