using UnityEngine.UI;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public float InitialTime = 10.0f;
    private float timeRemaining;
    private bool timerIsRunning = false;

    public void StartTimer() 
    {
        timeRemaining = InitialTime;
        timerIsRunning = true;
    }

    public void ResetTimer()
    {
        timeRemaining = InitialTime;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timerIsRunning = false;
                timeRemaining = 0.0f;
                StartCoroutine(FindObjectOfType<GameManagerK>().ReleaseBridgeSegments());
            }
        }
    }

    public string GetTimeToDisplay()
    {
        return timeRemaining > 0.0f? FormatTime(timeRemaining) : FormatTime(0.0f);
    }

    private string FormatTime(float remainingTime)
    {
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        int secondsFirstDecimalPoint = Mathf.FloorToInt((remainingTime - Mathf.Floor(remainingTime)) * 10) * 10;

        return string.Format("{0:00}:{1:00}", seconds, secondsFirstDecimalPoint);
    }
}
