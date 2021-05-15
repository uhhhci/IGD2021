using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{
	static Rigidbody rb;
	public static Vector3 dieVelocity;
    public int counter = 0;
    float dirX;
    float dirY;
    float dirZ;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
		dieVelocity = rb.velocity;
		dirX = Random.Range (0, 600);
		dirY = Random.Range (0, 600);
		dirZ = Random.Range (0, 600);

        if(counter == 20)
        {
        rb.AddForce (0,900,0);
        }

        if(counter > 20 && counter < 60 )
        {
		    rb.AddTorque (dirX, dirY, dirZ);
        }
        
        counter++;
    }
}
