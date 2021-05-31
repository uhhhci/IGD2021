using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanWaves : MonoBehaviour
{

    public GameObject Waves;
    private Vector3 UL = new Vector3(30f, -16.45871f, -40f);
    private Vector3 OR = new Vector3(-40f, -16.45871f, 40f);
    public bool wavesActive= true;
    public float speed;
    public float noise;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
        noise = 0.2f;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (wavesActive)
        {
       

            //Waves.transform.position = Vector3.Lerp(UL, OR, Mathf.PingPong(Time.time * speed, 1.0f));
            //Waves.transform.position = Vector3.Lerp(UR, OL, Mathf.PingPong(Time.time * speed, 1.0f));
            //Vector3 temp = Waves.transform.position;
            Vector3 temp = Vector3.Lerp(UL, OR, Mathf.PingPong(Time.time * speed, 1.0f));
            temp = new Vector3(temp.x + 5f * Mathf.Sin(Time.time * noise), temp.y, temp.z + 5f * Mathf.Sin(Time.time * noise));
            Waves.transform.position = temp;


        }



    }


}
