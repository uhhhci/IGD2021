using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundInput : MonoBehaviour
{
    public Phase phase;

    public float secondsUntilActionPhase = 2f;
    public float secondsPassed = 0f;
    public float timeLeft;

    // TODO set false at first, then update to true if all 4 users pressed "ready"
    // TODO but maybe ask jann about the "tutorial" game screen first
    bool canStartGame = true;
    public bool isBattleAnimationFinished;

    TextMesh descriptionTextMesh;
    string description;
    string title;

    public enum Phase
    {
        Decision,
        Action
    }

    // determines what happens dureing the action phase
    void ActionPhase()
    {
        description = "Fight!";
    }

    // determines what happens during the decision phase
    void DecisionPhase()
    {
        description = "Select your opponent and weapon!";
    }

    // decides which phase is the current phase
    void setCurrentPhase()
    {
        if (phase == Phase.Decision && secondsPassed >= secondsUntilActionPhase)
        {
            // TODO damage calculation
            phase = Phase.Action;
            secondsPassed = 0f;
        }

        if (phase == Phase.Action)
        {
            waitForBattleAnimation();

            if (isBattleAnimationFinished)
            {
                phase = Phase.Decision;
                isBattleAnimationFinished = false;
            }
        }
    }

    // TODO this should later access some other component which determines wheter the animation is finished
    void waitForBattleAnimation()
    {
        // TODO set this to true after the battle animation is finished to begin the next phase
        // !! waiting another 5 seconds is just a placeholder right now
        if (secondsPassed >= secondsUntilActionPhase)
        {
            isBattleAnimationFinished = true;
            secondsPassed = 0f;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        descriptionTextMesh = GameObject.Find("DescriptionText").GetComponent<TextMesh>();
        phase = Phase.Decision;
    }


    // Update is called once per frame
    void Update()
    {
        if (canStartGame)
        {
            title = phase == Phase.Action ? "Action Phase" : "Decision Phase";
            secondsPassed = secondsPassed += Time.deltaTime;
            timeLeft = secondsUntilActionPhase - secondsPassed;

            descriptionTextMesh.text = $"{title}\n{description}\n{timeLeft.ToString("F2")}";
            setCurrentPhase();

            if (phase == Phase.Action)
            {
                ActionPhase();
            }

            if (phase == Phase.Decision)
            {
                DecisionPhase();
            }

        }
    }
}
