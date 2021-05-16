using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{
	static Rigidbody rb;
	public static Vector3 dieVelocity;
    public int counter = 0;
	public bool restart = true;
    float dirX;
    float dirY;
    float dirZ;
	public static int rollResult = -1;
	public static bool done = false;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.anyKey)
		{
			restart = true;
		}

    	if(restart)
    	{
        	counter = 0;
			transform.position = new Vector3 (6.5f, 0.25f, -12f);
			rollResult = -1;
			done = false;
			restart = false;
    	}
      
		dieVelocity = rb.velocity;
		dirX = Random.Range (0, 1500);
		dirY = Random.Range (0, 1500);
		dirZ = Random.Range (0, 1500);

        if(counter == 20)
        {
        	rb.AddForce (0,900,0);
        }
		 
        if(counter > 20 && counter < 60 )
        {
		    rb.AddTorque (dirX, dirY, dirZ);
        	rb.AddForce (Random.Range (-10, 10),0,Random.Range (-10, 10));
        }
        
		if (counter > 200 && DieSideChecker.stationary)
		{
			rollResult = DieSideChecker.currentSide;
			Debug.Log("You rolled a "+ rollResult);
			done = true;
		}

        counter++;
    }
}
