using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneTimeDisplay : MonoBehaviour
{
    public CountdownTimer timer;
    void Update()
    {
        GetComponentInChildren<TextMesh>().text = timer.GetTimeToDisplay();
    }
}
