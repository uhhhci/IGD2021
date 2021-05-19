using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{
	static Rigidbody rb;
	private Vector3 initialPosition;
	public static Vector3 dieVelocity;
    public int counter = 0;
	private static bool restart = false;
    float dirX;
    float dirY;
    float dirZ;
	public static int rollResult = -1;
	private static bool done = false;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody> ();
		initialPosition = transform.position;
    }

	public static void rollDie() {
		restart = true;
		done = false;
	}

	public static bool isDone() {
		return done;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		if (!done) {
			if(restart)
			{
				counter = 0;
				// Debug.Log("Position: "+transform.position);
				transform.position = initialPosition;
				rollResult = -1;
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
			
			if(counter > 20 && counter < 100 )
			{
				rb.AddTorque (dirX, dirY, dirZ);
				rb.AddForce (Random.Range (-10, 10),0,Random.Range (-10, 10));
			}
			if (counter == 100)
			{
				DieSideChecker.done = false;
			}
			if (counter > 120 && DieSideChecker.done && !done)
			{
				rollResult = DieSideChecker.currentSide;
				done = true;
			}

			counter++;
		}
    }
}
