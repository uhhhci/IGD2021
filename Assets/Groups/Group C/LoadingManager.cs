using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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

    //publicar lista juegos en una archivo de strings.
    //leer lista y llamar clase abstracta de Minigame.
    //

    public void LoadMiniGame () {
        //SceneManager.LoadSceneAsync(level);
        this.showPicker();


    }

    public void LoadMainBoardGame() {
        //Load main board if we are not in it
    }

    private MiniGame selectRandomType() {
        Text freeForAll = GetComponent<Text>();
        Text singleVsTeam = GetComponent<Text>();
        Text teamVsTeam = GetComponent<Text>();



        freeForAll.color = Color.red;

        return null;
    }

    private MiniGame selectRandomGame() {

        //GameList.FREE_FOR_ALL

        return null;
    }

    private void DisplayLoadingScreen() {

    }

    private void HideLoadingScreen() {
        //MyGame game = new MyGame("My Awesome Game", "SceneName", MiniGameType.freeForAll);
        //game.sceneName = "WERR";
    }

    //Display UI that shows roulette to select from a random game
    public void showPicker() {

    }

    //Hides UI from picker
    public void hidePicker() {}

}


