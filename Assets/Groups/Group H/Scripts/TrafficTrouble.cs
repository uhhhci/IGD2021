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

    public void initializePlayers()
    {
        //Set up keys from the InputManager to every player
        //TODO
    }

    //We should reference a template scene which will present instrucitons with a simple image and a Text box to fill with the instructions
    public void LoadInstructions(string instructions, string previewImage)
    {
        //TODO
    }

    //Display FINISH and load the ending sequence
    private void LoadGameOver()
    {
        //TODO
    }


    /**
     * You should call this method whenever your minigame is finished
     * Receives arrays of ids from your players depending on their positions
     * 
     * This receives an array of player ids dependig on their final position in the minigame (IN-GAME SCORES ARE NOT NEEDED, JUST POSITION)
     * Some arrays can be null if no one ended in that position.
    **/
    public void MiniGameFinished(int[] firstPlace, int[] secondPlace, int[] thirdPlace, int[] fourthPlace)
    {
        //Save results in PlayerPrefs

        //Display Game Over

        //Display Results

        //Back to the MainBoard Game
        LoadingManager.Instance.LoadMainBoardGame();

    }


}
