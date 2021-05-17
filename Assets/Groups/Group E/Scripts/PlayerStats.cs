using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int rounds;
    public Text text;
    public int CurrentZone;
    public int position;
    // Start is called before the first frame update
    void Start()
    {
        rounds = 1;
    }

    public void CountRound()
    {
        rounds += 1;
        if(rounds < 4)
        {
            text.text = "Round: " + rounds + "/3";
        } else
        {
            text.text = "You finished!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
