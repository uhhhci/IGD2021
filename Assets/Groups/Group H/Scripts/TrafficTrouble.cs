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

    public void initializePlayers() {
        //Set up keys from the InputManager to every player
    }

    //We should reference a template scene which will present instrucitons with a simple image and a Text box to fill with the instructions
    public void LoadInstructions(string instructions, string previewImage) {
        //TODO
    }

    //Display FINISH and load the ending sequence
    private void LoadGameOver() {
        
    }

    //Saves results in PlayerPrefs
    public void MiniGameFinished(int[] firstPlace, int[] secondPlace, int[] thirdPlace, int[] fourthPlace) {
        //Save results

        //Back to the MainBoard Game
        LoadingManager.Instance.LoadMainBoardGame();

    }

    
}
