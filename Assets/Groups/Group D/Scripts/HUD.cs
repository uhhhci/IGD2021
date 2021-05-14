using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public List<Text> creditDisplays;
    public List<Text> brickDisplays;
    public Text actionPointDisplay;
    public Text roundDisplay;
    
    public void updateActionPoints(int actionPoints) {
        actionPointDisplay.text = "AP: " + actionPoints.ToString();
    }

    public void updateRound(int round) {
        roundDisplay.text = "Round: " + round.ToString();
    }

    public void updateCredits(int player, int amount) {
        creditDisplays[player].text = ": " + amount.ToString();
    }

    public void updateBricks(int player, int amount) {
        brickDisplays[player].text = ": " + amount.ToString();
    }
}
