using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerCTC : MonoBehaviour
{
    //left team
    public PlayerInput player1;
    public PlayerInput player2;

    //right team
    public PlayerInput player3;
    public PlayerInput player4;

    void Start()
    {
        List<PlayerInput> playerInputs = new List<PlayerInput>()
        {
            player1,
            player2,
            player3,
            player4
        };

        //optional return value is not used
        InputManager.Instance.AssignPlayerInput(playerInputs);
    }

}
