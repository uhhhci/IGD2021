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
}