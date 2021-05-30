using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I attached the script to the gameObject "PauseManager".
// Not sure if that's good over time.

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuPrefab;
    public GameObject canvasPrefab;
    private Canvas _canvas;
    private bool pauseIsOpen=false;

/////////////////////////////////////////////////////////////
// THAT PART IS ALSO IN THE OTHER MANAGERS.
    public static PauseManager Instance;
    private void Awake () {
        if(!Instance) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }
////////////////////////////////////////////////////////////

    private Canvas SceneCanvas {
      get{
        // Check if canvas variable is set
        if(_canvas == null){
          // If not set, look in scene for canvas
          _canvas = FindObjectOfType<Canvas>();
          if(_canvas == null){
            // If no canvas in scene, create one
            _canvas = Instantiate(canvasPrefab).GetComponent<Canvas>();
          }
        }
        return _canvas;
      }
    }

    private GameObject pauseMenuInstance;

    public void OpenPauseMenu(){
      // Checking to see if one exists
      if(pauseMenuInstance == null){
        //Creates a new game menu
      Instantiate(pauseMenuPrefab, SceneCanvas.transform);
    } else{
      // Set currently existing pause menu to true
      pauseMenuInstance.SetActive(true);
    }
    pauseIsOpen=true;
  }

  public void ClosePauseMenu(){
     //this.gameObject.SetActive(false);
     //Destroy(this.gameObject);
     Destroy(GameObject.Find("Canvas(Clone)"));
     pauseIsOpen=false;
  }

  public void Update(){
    // Space is down
    if(Input.GetKeyDown(KeyCode.Space)){
      if(pauseIsOpen==false){
      OpenPauseMenu();
    }
    else if(pauseIsOpen==true){
      ClosePauseMenu();
    }
    }
  }
}
