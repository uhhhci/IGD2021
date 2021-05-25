public class KartRacingGame : MiniGame
{

    public override string getDisplayName(){
        return "Kart Racing";
    }
    public override string getSceneName(){
        return "KartRacingMinigame";
    }

    public override MiniGameType getMiniGameType()
    {
        return MiniGameType.freeForAll;
    }
}