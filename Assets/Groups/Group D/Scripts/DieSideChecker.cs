using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSideChecker : MonoBehaviour
{
	Vector3 dieVelocity;
	public static bool stationary;
    public static int currentSide = 0;
	public static bool done = false;
    
    // Update is called once per frame
    void Update()
    {
		dieVelocity = DieScript.dieVelocity;
		stationary = (dieVelocity.x == 0f && dieVelocity.y == 0f && dieVelocity.z == 0f);
    }

    void OnTriggerStay(Collider col)
	{
		//Debug.Log("Triggered");
		if (stationary)
		{
			switch (col.gameObject.name) {
			case "Side 1":
                currentSide = 6;
				break;
			case "Side 2":
                currentSide = 5;
				break;
			case "Side 3":
                currentSide = 4;
				break;
			case "Side 4":
                currentSide = 3;
				break;
			case "Side 5":
                currentSide = 2;
				break;
			case "Side 6":
                currentSide = 1;
				break;
			}
			done = true;
		}
	}
}
