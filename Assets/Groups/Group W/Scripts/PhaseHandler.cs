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
    public static bool isActionPhaseFinished;
    public static bool isDecisionPhaseFinished;
    public static int roundCount;

    public enum Phase
    {
        Decision,
        Action
    }

    // decides which phase is the current phase
    void SetCurrentPhase()
    {
        // decision phase only lasts x seconds, then switch to action phase
        if (phase == Phase.Decision && secondsPassed >= secondsUntilActionPhase)
        {
            isDecisionPhaseFinished = true;
            isActionPhaseFinished = false;
            phase = Phase.Action;
            secondsPassed = 0f;
        }

        if (phase == Phase.Action)
        {
            // WaitForActivePhaseEnd();

            // action phase is over as soon as all damage is dealt, will be updated by ActionPhase.cs
            if (isActionPhaseFinished)
            {
                phase = Phase.Decision;
                roundCount += 1;
            }
        }
    }

    //// TODO this should later access some other component which determines wheter the animation is finished
    //void WaitForActivePhaseEnd()
    //{
    //    // TODO set this to true after the battle animation is finished to begin the next phase
    //    // !! waiting another 5 seconds is just a placeholder right now
    //    if (secondsPassed >= secondsUntilActionPhase)
    //    {
    //        isActionPhase = true;
    //        secondsPassed = 0f;
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        phase = Phase.Decision;
        roundCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        secondsPassed = secondsPassed += Time.deltaTime;
        timeLeft = secondsUntilActionPhase - secondsPassed;
        SetCurrentPhase();
        isActionPhaseFinished = ActionPhase.isActionPhaseFinished;
    }
}
