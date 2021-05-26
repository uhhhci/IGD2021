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

    public void updateCredits(int player, int amount) {
        creditDisplays[player].text = getCreditText(amount);
    }

    public void updateCredits(int player, int amount, int costs) {
        creditDisplays[player].text = getCreditText(amount) + getCostsSuffix(costs);
    }

    private string getCreditText(int amount) {
        return ": " + amount.ToString();
    }

    public void updateBricks(int player, int amount) {
        brickDisplays[player].text = ": " + amount.ToString();
    }

    public void setBrickBobble(int player, bool value) {
        bricks[player].setBobbing(value);
    }

    public void setCreditBobble(int player, bool value) {
        credits[player].setBobbing(value);
    }
}
