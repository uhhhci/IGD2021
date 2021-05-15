using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{

    bool minifigure1_isDead = false;
    bool minifigure2_isDead = false;
    public GameObject minifigure1;
    public GameManager gameManager;
    void Update()
    {
        if (!minifigure1_isDead && minifigure1.gameObject.transform.position.y < 0.5f)
        {
            minifigure1.GetComponent<MinifigController>().ClearMoves();
            minifigure1_isDead = true;
        }

        if (minifigure1_isDead && minifigure2_isDead)
        {
            gameManager.GetComponent<GameManager>().GameOver();
        }
    }
}
