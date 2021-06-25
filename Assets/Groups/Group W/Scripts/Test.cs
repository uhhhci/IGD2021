using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InterconnectionsAssignment : MonoBehaviour
{
    // 
    List<PlayerInput> playerInputs;

    // Start is called before the first frame update
    void Start()
    {
        playerInputs = new List<PlayerInput>();
        foreach (Transform child in transform)
        {
            playerInputs.Add(child.GetComponent<PlayerInput>());
            print($"[BEFORE AssignPlayerInput()] defaultControlScheme: {child.GetComponent<PlayerInput>().defaultControlScheme}");
        }

        InputManager.Instance.AssignPlayerInput(playerInputs);

         foreach (Transform child in transform)
         {
            print($"[AFTER AssignPlayerInput()] defaultControlScheme: {child.GetComponent<PlayerInput>().defaultControlScheme}");
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
