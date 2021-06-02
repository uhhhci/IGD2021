using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMoverLeft1 : MonoBehaviour
{
    public float rotation_speed, t, startRot, coolDown, coolDownDur, turningDur;
    public bool arrowAct;
    // Start is called before the first frame update
    void Start()
    {
        coolDownDur = 5f;
        turningDur = 5f;
        arrowAct = true;
        rotation_speed = 1f;
        startRot = -5f;
        coolDown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= coolDown + coolDownDur)
        {
            arrowAct = true;
            coolDown = 0f;
            gameObject.active = arrowAct;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        startRot = Time.time;

        if (Time.time <= (startRot+turningDur))
        {
            GenerateRings.instance.RotateRing(1, rotation_speed);
        }
        else
        {
            arrowAct = false;
            gameObject.active = arrowAct;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        arrowAct = false;
        coolDown = Time.time;
        
        gameObject.active = arrowAct;


    }




}
