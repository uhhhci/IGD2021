using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCharacterAssigner : MonoBehaviour
{
    // add player inputs in order
    public List<GameObject> hudCharacters;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++) {
            InputManager.Instance.ApplyPlayerCustomization(hudCharacters[i], i+1);
        }

        
    }
}
