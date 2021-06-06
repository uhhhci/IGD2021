using UnityEngine.UI;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public float InitialTime = 10.0f;
    public Text timerDisplay;
    private float timeRemaining;
    private bool timerIsRunning = false;

    public void StartTimer() 
    {
        timeRemaining = InitialTime;
        timerIsRunning = true;
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
            DisplayRemainingTime(timeRemaining);
        }
    }

    void DisplayRemainingTime(float remainingTime)
    { 
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        int secondsFirstDecimalPoint = Mathf.FloorToInt((remainingTime - Mathf.Floor(remainingTime)) * 10) * 10;

        timerDisplay.text = string.Format("{0:00}:{1:00}", seconds, secondsFirstDecimalPoint);
    }
}
