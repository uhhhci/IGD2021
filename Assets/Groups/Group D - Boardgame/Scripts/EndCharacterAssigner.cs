using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class EndCharacterAssigner : MonoBehaviour
{
    // add player inputs in order
    public List<GameObject> hudCharacters;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Assigning player customizations");
        for (int i = 0; i < 4; i++) {
            if (!PlayerPrefs.GetString("PLAYER" + (i+1).ToString() + "_AI").Equals("True")) {
                // skip AIs
                InputManager.Instance.ApplyPlayerCustomization(hudCharacters[i], i+1);
            }
        }
    }
}
