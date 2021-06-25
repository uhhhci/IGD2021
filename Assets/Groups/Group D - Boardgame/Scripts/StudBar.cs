using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudBar : MonoBehaviour
{
    private enum State {
        RACING, // true party person state can be achieved
        WINNER, // true party person state has been achieved by this player
        LOSER, // true party person state has been achieved by another player
    }
    public Material filledMaterial;
    public Material emptyMaterial;

    public List<GameObject> studs;

    private State state = State.RACING;
    private int filledStuds = 0;

    // duration in secondsd for a single iteration of the "shine" 
    // animation displayed when this player is the "true party person"
    public float shineDuration = 1.0f; 
    private int shineStuds = 0; // current "filled" studs used for the shine duration
    private float shineTimeSinceLastFrame = 0f; // number of seconds since the last "shine animation frame"
    private float shineFrameTime = 0f; // time for a single "shine animation frame"

    // value between 0 and 1; 1 = bar is completely filled, 0 = bar is completely empty
    public void setFillRatio(float newRatio) {
        filledStuds = (int) Mathf.Ceil(newRatio * studs.Count); // returns a value between 0 and studsCount

        int i = 0;
        foreach (GameObject stud in studs) {
            foreach (Renderer r in stud.GetComponentsInChildren<Renderer>()) {
                if (filledStuds > i) {
                    r.material = filledMaterial;
                }
                else {
                    r.material = emptyMaterial;
                }
            }
            i++;
        }
    }

    // call this method to indicate that the "true party person" state has been achieved
    // use the parameter to indicate whether it has been achieved by this player or not
    public void setStateTaken(bool byThisPlayer) {
        if (byThisPlayer) {
            state = State.WINNER;
        }
        else {
            state = State.LOSER;

            foreach (GameObject stud in studs) {
                foreach (Renderer r in stud.GetComponentsInChildren<Renderer>()) {
                    r.material = emptyMaterial;
                }
            }
        }
    }

    /// whether this player is the true party person
    public bool isItThisPlayer() {
        return state == State.WINNER;
    }

    void Awake() {
        shineFrameTime = shineDuration / studs.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.WINNER) {
            shineTimeSinceLastFrame += Time.deltaTime;

            int newStuds = shineStuds;

            while (shineTimeSinceLastFrame > shineFrameTime) {
               shineTimeSinceLastFrame -= shineFrameTime;
                newStuds = (newStuds + 1) % (studs.Count+1); // +1 so that the last stud/credit is also used
            }

            if (newStuds != shineStuds) {
                shineStuds = newStuds;
                setFillRatio(((float) shineStuds) / studs.Count);
            }
        }
    }
}
