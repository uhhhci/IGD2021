using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficTimer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 45f;
    public Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        //print(currentTime);
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 4)
        {
            countdownText.color = Color.red;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
        }

        if (currentTime <= 0)
        {
            //Leite Ende ein
        }

    }
}
