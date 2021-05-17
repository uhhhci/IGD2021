using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int rounds;
    public Text text;
    public int CurrentZone;
    // Start is called before the first frame update
    void Start()
    {
        rounds = 0;
    }

    public void CountRound()
    {
        rounds += 1;
        text.text = "Round: " + rounds + "/3";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
