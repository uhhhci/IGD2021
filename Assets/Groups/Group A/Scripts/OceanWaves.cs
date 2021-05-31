using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanWaves : MonoBehaviour
{

    public GameObject Waves;
    private Vector3 UL = new Vector3(65f, 12.24871f, -127.5245f);
    private Vector3 OR = new Vector3(-76f, 12.24871f,78f);
    public bool wavesActive= true;
    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        if (wavesActive)
        {
       
            Waves.transform.position = transform.TransformVector( Vector3.Lerp(OR, UL, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f));

            
        }











    }


}
