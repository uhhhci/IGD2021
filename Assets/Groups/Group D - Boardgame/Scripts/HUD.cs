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

    public List<TurnAnimationCredit> credits;
    public List<TurnAnimationBrick> bricks;
    
    public void updateActionPoints(int actionPoints) {
        actionPointDisplay.text = getAPText(actionPoints);
    }

    public void updateActionPoints(int actionPoints, int costs) {
        actionPointDisplay.text = getAPText(actionPoints) + getCostsSuffix(costs);
    }

    private string getAPText(int amount) {
        return "AP: " + amount.ToString();
    }

    private string getCostsSuffix(int amount) {
        return "(-" + amount.ToString() + ")";
    }

    public void updateRound(int round) {
        roundDisplay.text = "Round: " + round.ToString();
    }
}
