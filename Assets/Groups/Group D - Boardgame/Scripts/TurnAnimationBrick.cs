using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAnimationBrick : MonoBehaviour
{
    public float rotationSpeed = -90f;
    public float bobbingSpeed = 20f;
    public float boobingAmplitude = 0.2f;
    private bool bobbing = false;
    private bool bobbingWasDeactivated = false;

    private Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, rotationSpeed * Time.deltaTime);

        if (bobbing) {
            Vector3 newPos = initialPos;
            newPos.y += Mathf.Sin(Time.timeSinceLevelLoad * bobbingSpeed) * boobingAmplitude;
            transform.position = newPos;
        }
        else if (bobbingWasDeactivated) {
            transform.position = initialPos;
            bobbingWasDeactivated = false;
        }
    }

    public void setBobbing(bool value) {
        if (!bobbing && value) { // if bobbing is turned on
            initialPos = transform.position;
        }
        else if (bobbing && !value) { // if bobbing is turned off 
            bobbingWasDeactivated = true;
        }
        bobbing = value;
    }
}
