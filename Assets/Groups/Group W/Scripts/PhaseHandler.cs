using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class used to switch between battle phases
 */ 
public class PhaseHandler : MonoBehaviour
{
    public static Phase phase;
    public static float timeLeft;

    public float secondsUntilActionPhase = 2f;
    public float secondsPassed = 0f;
    

    public bool isBattleAnimationFinished;

    public enum Phase
    {
        Decision,
        Action
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
        phase = Phase.Decision;
    }

    // Update is called once per frame
    void Update()
    {
        secondsPassed = secondsPassed += Time.deltaTime;
        timeLeft = secondsUntilActionPhase - secondsPassed;
        setCurrentPhase();
    }
}
