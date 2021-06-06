using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text countdownText;
    int countdown;
    float timeAtStart;
    string txt_after_cntdwn;

    // Update is called once per frame
    void Update()
    {
        countdown = (int) (timeAtStart - Time.time);

        switch (countdown)
        {
            case 4:
                countdownText.text = "3";
                break;
            case 3:
                countdownText.text = "2";
                break;
            case 2:
                countdownText.text = "1";
                break;
            case 1:
                countdownText.text = txt_after_cntdwn;
                break;
            default:
                countdownText.text = "";
                break;
        }
    }

    public void StartCountDown(bool isStart)
    {
        timeAtStart = Time.time + 4.999f;
        if (isStart){
            txt_after_cntdwn = "Smash!";
        }
        else
        {
            txt_after_cntdwn = "The End!";
        }
            

    }
}
