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

    public void setBrickBobble(int player, bool value) {
        bricks[player].setBobbing(value);
    }

    public void setCreditBobble(int player, bool value) {
        credits[player].setBobbing(value);
    }
}
