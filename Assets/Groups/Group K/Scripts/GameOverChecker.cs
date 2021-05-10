using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{

    public GameObject minifigure1;
    void Update()
    {
        if (minifigure1.gameObject.transform.position.y < 2.0f)
        {
            //minifigure1.GetComponent<CharacterController>().enabled = false;
        }
    }
}
