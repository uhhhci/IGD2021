using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;
    [SerializeField] private GameObject _player3;
    [SerializeField] private GameObject _player4;

    // Update is called once per frame
    void Update()
    {
        bool aB1 = _player1.activeSelf;
        bool aB2 = _player2.activeSelf;
        bool aB3 = _player3.activeSelf;
        bool aB4 = _player4.activeSelf;

        if(aB1 && !(aB2 || aB3 || aB4))
        {
            WinGame(_player1);
        }
        else if (aB2 && !(aB1 || aB3 || aB4))
        {
            WinGame(_player1);
        }
        else if (aB3 && !(aB1 || aB2 || aB4))
        {
            WinGame(_player1);
        }
        else if (aB4 && !(aB2 || aB3 || aB1))
        {
            WinGame(_player1);
        }
        else if(!(aB1 || aB2 || aB3 || aB4))
        {
            List<GameObject> winners = new List<GameObject>();

            if (aB1) { winners.Add(_player1); };
            if (aB2) { winners.Add(_player2); };
            if (aB3) { winners.Add(_player3); };
            if (aB4) { winners.Add(_player4); };

            GameDraw(winners);
        }
    }

    public void GameDraw(List<GameObject> winners)
    {
        Time.timeScale = 0;
        Debug.Log("Its a Draw!");
    }

    public void WinGame(GameObject winner)
    {
        Time.timeScale = 0;
        Debug.Log(winner.name + " Wins the Game!");
    }
}
