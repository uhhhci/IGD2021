using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MiniGameType {
    freeForAll,
    singleVsTeam,
    teamVsTeam
}
abstract public class MiniGame : MonoBehaviour
{
    public abstract string getDisplayName();
    public abstract string getSceneName();

    public abstract MiniGameType getMiniGameType();

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
