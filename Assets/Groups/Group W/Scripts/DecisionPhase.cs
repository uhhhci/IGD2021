using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionPhase : MonoBehaviour
{
    public PhaseHandler.Phase phase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        phase = PhaseHandler.phase;
    }
}
