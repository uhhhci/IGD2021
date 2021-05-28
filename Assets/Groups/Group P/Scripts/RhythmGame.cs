


public class RhythmGame : MiniGame {

    public override string getDisplayName() {
        return "Rhythm Game";
    }

    public override string getSceneName()  {
        return "RhythmGameScene";
    }

    public override MiniGameType getMiniGameType() {
        return MiniGameType.freeForAll;
    }

}