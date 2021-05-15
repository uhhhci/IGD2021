using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;

    //Should we have all the games in a single list?
    //SHould we have different list per game type?
    //How do we obtain the games?
    private List<MiniGame> minigames = new List<MiniGame>();

    private void Awake () {
        if(!Instance) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
            
        }
    }

    public void LoadMiniGame (string level) {
        SceneManager.LoadSceneAsync(level);
    }

    public void LoadMainBoardGame() {
        //Load main board if we are not in it
    }

    public MiniGame selectRandomGame() {
        return null;
    }

    private void DisplayLoadingScreen() {

    }

    private void HideLoadingScreen() {
        MyGame game = new MyGame("My Awesome Game", "SceneName", MiniGameType.freeForAll);
        game.sceneName = "WERR";
    }

    //Display UI that shows roulette to select from a random game
    public void showPicker() {}

    //Hides UI from picker
    public void hidePicker() {}

}

public class MyGame : MiniGame {

    public MyGame(string displayName, string sceneName, MiniGameType gameType): base(displayName, sceneName, gameType) {
        
    }
}
