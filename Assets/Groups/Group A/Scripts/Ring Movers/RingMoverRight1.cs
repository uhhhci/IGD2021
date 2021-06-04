using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMoverRight1 : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RingMoverManager.instance.br_enter = Time.time;
            Debug.Log("Mover: first touch");
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            if (RingMoverManager.instance.br_active)
            {
                if (Time.time <= RingMoverManager.instance.br_enter + RingMoverManager.instance.dur)
                {
                    GenerateRings.instance.RotateRing(1, -RingMoverManager.instance.speed);
                    Debug.Log("Mover: turn the table");
                }

                else
                {
                    RingMoverManager.instance.br_exit = Time.time;
                    RingMoverManager.instance.br_active = false;
                    this.gameObject.SetActive(false);
                    Debug.Log("Mover: standest zu lang drauf");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            RingMoverManager.instance.br_exit = Time.time;
            RingMoverManager.instance.br_active = false;
            Debug.Log("Mover: Knopf verlassen");
        }

    }




}
