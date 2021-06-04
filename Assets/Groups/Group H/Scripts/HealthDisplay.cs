using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    // Initialize health integer and text player 1-4
    public int healthP1 = 3;
    public int healthP2 = 3;
    public int healthP3 = 3;
    public int healthP4 = 3;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ReduceLifePlayer1()
    {
        healthP1--;
    }
    public void ReduceLifePlayer2()
    {
        healthP2--;
    }
    public void ReduceLifePlayer3()
    {
        healthP3--;
    }
    public void ReduceLifePlayer4()
    {
        healthP4--;
    }

    // Update is called once per frame
    void Update()
    {
        // Health gauge display player 1 to 4
        healthText.text = "     LIFE P1: " + healthP1 + "                  LIFE P2: " + healthP2 + "                               LIFE P3: " + healthP3 + "                  LIFE P4: " + healthP4;

        // Reduce health with space bar for texting (replace with collision player vs car at a later time)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReduceLifePlayer1();
            //GetComponent<HealthDisplay>().ReduceLifePlayer1();
        }

        if (healthP1 <= 0)
        {
            healthP1 = 0;
        }
        if (healthP2 <= 0)
        {
            healthP2 = 0;
        }
        if (healthP3 <= 0)
        {
            healthP3 = 0;
        }
        if (healthP4 <= 0)
        {
            healthP4 = 0;
        }
    }
}
