using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroupP
{
public class GameEventSystem : MonoBehaviour
{
    public static GameEventSystem current;
    public event Action onHit;
    public event Action onBeat;
    public event Action onStartDance;

    private void Awake()
    {
        current = this;
    }

    public void Hit()
    {
        onHit?.Invoke();
    }

    public void Beat()
    {
        onBeat?.Invoke();
    }
    public void StartDance()
    {
        onStartDance?.Invoke();
    }

}

}

