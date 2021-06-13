using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;
    private MinifigControllerWTH controller; 
    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<MinifigControllerWTH>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"{controller.playerPoints}";
    }
}
