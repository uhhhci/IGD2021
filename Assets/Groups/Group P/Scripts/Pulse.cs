using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{

    private static float beatsPerSecond;

    private static float songOffset;

    private static int numberOfBeats;

    private static bool playing = false;

    private bool started = false;

    private float timeAtLastPulse = 0;

    float before, after;

    public static void setBPM(float beatsPerMinute) {
        beatsPerSecond = beatsPerMinute / 60f;
    }

    public static void setOffset(float offset) {
        songOffset = offset;
    }

    public static void setNumberOfBeats(int beats) {
        numberOfBeats = beats;
    }

    public static void play() {
        playing = true;
    }

    public static void stop() {
        playing = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!started && playing) {
            timeAtLastPulse = Time.time + songOffset;
            started = true;
            StartCoroutine("pulsate");
        }
        if(started && !playing) {
            playing = false;
        }
    }

    private IEnumerator pulsate() {
        yield return new WaitForSeconds(songOffset);
        StartCoroutine("onePulse");
    }

    private IEnumerator onePulse() {
        float now = Time.time;
        float next = 1f / beatsPerSecond / 2f;
        if(now - timeAtLastPulse > next) {
            next = next - (now - timeAtLastPulse - next);
        }
        timeAtLastPulse = now;
        scaleUp();
        
        yield return new WaitForSeconds(next);
        scaleDown();

        now = Time.time;
        next = 1f / beatsPerSecond / 2f;
        if(now - timeAtLastPulse > next) {
            next = next - (now - timeAtLastPulse - next);
        }
        timeAtLastPulse = now;
        
        
        yield return new WaitForSeconds(1f / beatsPerSecond / 2f);
        if (started && playing) {StartCoroutine("onePulse"); }
    }

    private void scaleUp() {
        transform.localScale = new Vector3(1.07f, 1.07f, 1f);
    }

    private void scaleDown() {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }


}
