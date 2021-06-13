using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoardgamePlayer : MonoBehaviour
{
    public TurnManager turnManager;

    public int playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnMoveDpad(InputValue value) {
        // get the normalized movement vector 
        // (e.g. W + A are pressed -> something around (-0.7,0.7))
        Vector2 input = value.Get<Vector2>();
        input.Normalize();

        if (input.x > 0.9) {
            turnManager.reactToMove(TurnManager.Directions.RIGHT, playerNumber);
        } else if (input.x < -0.9) {
            turnManager.reactToMove(TurnManager.Directions.LEFT, playerNumber);
        } else if (input.y > 0.9) {
            turnManager.reactToMove(TurnManager.Directions.UP, playerNumber);
        } else if (input.y < -0.9) {
            turnManager.reactToMove(TurnManager.Directions.DOWN, playerNumber);
        } // else: multiple keys are pressed -> do nothing
    }

    // private void OnMenu()
    // {
    //     print("OnMenu");
    // }

    private void OnNorthPress()
    {
        turnManager.reactToNorth(playerNumber);
    }

    // private void OnNorthRelease()
    // {
    //     print("OnNorthRelease");
    // }

    private void OnEastPress()
    {
        turnManager.reactToEast(playerNumber);
    }

    // private void OnEastRelease()
    // {
    //     print("OnEastRelease");
    // }

    private void OnSouthPress()
    {
        turnManager.reactToSouth(playerNumber);
    }

    // private void OnSouthRelease()
    // {
    //     print("OnSouthRelease");
    // }

    private void OnWestPress()
    {
        turnManager.reactToWest(playerNumber);
    }

    // private void OnWestRelease()
    // {
    //     print("OnWestRelease");
    // }
}
