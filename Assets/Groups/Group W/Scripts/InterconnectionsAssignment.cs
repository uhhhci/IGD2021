using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

// this class should never contain anything else than assinging the player input,
// since otherwise, the inputs are not responsive anymore
// only put this back to the more obvious LegoPaperScissorsMinigame class if group C resolved the issue
public class Test : MonoBehaviour
{
    List<PlayerInput> playerInputs;

    // Start is called before the first frame update
    void Start()
    {
        playerInputs = new List<PlayerInput>();
        foreach (Transform child in transform)
        {
            playerInputs.Add(child.GetComponent<PlayerInput>());
            // print($"[BEFORE AssignPlayerInput()] defaultControlScheme: {child.GetComponent<PlayerInput>().defaultControlScheme}");
        }

        // assigns the player input in the order they were given in the array
        InputManager.Instance.AssignPlayerInput(playerInputs);

         //foreach (Transform child in transform)
         //{
         //   print($"[AFTER AssignPlayerInput()] defaultControlScheme: {child.GetComponent<PlayerInput>().defaultControlScheme}");
         //}
    }
}
