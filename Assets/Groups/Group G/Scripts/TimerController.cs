using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public Text TimeCounter;
    public float GametimeMinutes = 3.0f;

    private TimeSpan TimePlaying;
    private float TimeLeft;
    private bool TimerGoing;
    
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        TimeCounter.text = "Time: 03:00";
    }

    public void BeginTimer()
    {
        TimerGoing = true;
        TimeLeft = GametimeMinutes * 60.0f;

        StartCoroutine(UpdateTimer());
    }
    public void EndTimer()
    {
        TimerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (TimerGoing)
        {
            TimeLeft -= Time.deltaTime;
            TimePlaying = TimeSpan.FromSeconds(TimeLeft);
            string timePlayingStr = "Time: " + TimePlaying.ToString("mm':'ss");
            TimeCounter.text = timePlayingStr;

            yield return null;
        }
    }

    public float GetTimeLeft()
    {
        return TimeLeft;
    }
}
