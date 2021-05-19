using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerJ : MonoBehaviour
{
    // Start is called before the first frame update
    public int deathCount1 = 0;
    public int deathCount2 = 0;
    public Text team1DeathCount;
    public Text team2DeathCount;
    void Start()
    {
        
    }

    public void UpdateDeath(bool isTeam1)
    {
        if (isTeam1) 
        {
            deathCount1++;
            team1DeathCount.text = "Deaths: " + deathCount1;
        }
        else
        {
            deathCount2++;
            team2DeathCount.text = "Deaths: " + deathCount2;
        }
        
           
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
