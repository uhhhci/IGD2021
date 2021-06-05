using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroupP
{

public class DanceManager : MonoBehaviour
{
    float beatsPerMinute;
    float sekPerBeat;
    // For the onBeat-Animation: time to accent of animation / length of animation
    float accentpoint;
    float offset;

    void Start()
    {
        beatsPerMinute = 60f;
        sekPerBeat = 60f / beatsPerMinute;
        offset = 0.7f;
        InvokeRepeating("DanceEvent", (4+offset)*sekPerBeat, 4*sekPerBeat);
        InvokeRepeating("BeatEvent", offset*sekPerBeat, sekPerBeat/2);
    }

    void DanceEvent()
    {
        
        GameEventSystem.current.Hit();
        
    }

    void BeatEvent()
    {
        GameEventSystem.current.Beat();
    }
}
}
