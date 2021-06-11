using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 3;
    public int numberOfHearts = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int ownID;

    public TrafficTrouble gameManager;

    void Start()
    {
        gameManager.SubmitHealth(ownID, health);
    }

    public void reduceHealth()
    {
        if (health > 0)
        {
            health--;
            gameManager.SubmitHealth(ownID, health);
        }
    }

    public void increaseHealth()
    {
        if (health < 3)
        {
            health++;
            gameManager.SubmitHealth(ownID, health);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health > numberOfHearts)
        {
            health = numberOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {//Show full heart
                hearts[i].sprite = fullHeart;
            }
            else
            {//Show empty heart
                hearts[i].sprite = emptyHeart;
            }

            //Make hearts invisible if we reduce the number of total hearts
            if (i < numberOfHearts)
            {//Show hearts
                hearts[i].enabled = true;
            }
            else
            {//Hide hearts
                hearts[i].enabled = false;
            }
        }   
    }
}
