using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

// this class should never contain anything else than assinging the player input,
// since otherwise, the inputs are not responsive anymore
// only put this back to the more obvious LegoPaperScissorsMinigame class if group C resolved the issue
public class InterconnectionsAssignment : MonoBehaviour
{
    List<PlayerInput> playerInputs;
    List<string> playerIdsStrings;

    // Start is called before the first frame update
    void Start()
    {
        
        
        playerInputs = new List<PlayerInput>();
        playerIdsStrings = new List<string>();

        foreach (Transform child in transform)
        {
            playerInputs.Add(child.GetComponent<PlayerInput>());
            print($"added player input: {child.GetComponent<PlayerInput>()}");
            // print($"[BEFORE AssignPlayerInput()] defaultControlScheme: {child.GetComponent<PlayerInput>().defaultControlScheme}");
        }

        for (int index = 1; index <= playerInputs.Count; index++)
        {
            playerIdsStrings.Add(index.ToString());
            print($"added player id strings: {index.ToString()}");
        }

        for (int index = 1; index <= playerInputs.Count; index++)
        {
            // assigns the player input in the order they were given in the array
            //  InputManager.Instance.AssignPlayerInput(playerInputs, playerIdsStrings);

            var interconnectionsAi = gameObject.GetComponent<InterconnectionsAi>();
            var playerName = playerInputs[index - 1].transform.Find("LegoPaperScissors").GetComponent<PlayerProperties>().playerName;
            print($"player name is {playerName}");
            print($"interconnectionsAi is: {interconnectionsAi}");

            var IsAiPlayer = interconnectionsAi.IsAiPlayer(playerName);
            print($"isAiPlayer is: {IsAiPlayer}");

            //if (!IsAiPlayer)
            //{
            //    InputManager.Instance.ApplyPlayerCustomization(playerInputs[index - 1].transform.Find("Minifig Character").gameObject, index);
            //}
            
        }

        //foreach (Transform child in transform)
        //{
        //   print($"[AFTER AssignPlayerInput()] defaultControlScheme: {child.GetComponent<PlayerInput>().defaultControlScheme}");
        //}
    }
}
