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
    public bool isActionPhaseFinished;
    public bool isDecisionPhaseFinished;
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
            // print("now beginning decision phase");
            isDecisionPhaseFinished = true;
            isActionPhaseFinished = false;
            phase = Phase.Action;
            secondsPassed = 0f;
        }

        if (phase == Phase.Action)
        {
            isActionPhaseFinished = ActionPhase.isActionPhaseFinished;

            // action phase is over as soon as all damage is dealt, will be updated by ActionPhase.cs
            if (isActionPhaseFinished)
            {
                isDecisionPhaseFinished = false;
                phase = Phase.Decision;
                roundCount += 1;
            }
        }
    }

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
        
    }
}
