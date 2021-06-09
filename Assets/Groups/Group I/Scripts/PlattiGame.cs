public class PlattiGame : MiniGame
{

    public override string getDisplayName()
    {
        return "Platti Game";
    }
    public override string getSceneName()
    {
        return "PlattiGame";
    }

    public override MiniGameType getMiniGameType()
    {
        return MiniGameType.freeForAll;
    }

    private void Start()
    {
        // todo
    }
}
