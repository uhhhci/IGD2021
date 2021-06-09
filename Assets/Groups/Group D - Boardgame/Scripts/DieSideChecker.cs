using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSideChecker : MonoBehaviour
{
	Vector3 dieVelocity;
	Vector3 dieVelocity2;
	public static bool stationary;
    public static int currentSide = 0;
    public static int currentSide2 = 0;
	public static bool done = false;
    
    // Update is called once per frame
    void Update()
    {
		dieVelocity = DieScript.dieVelocity;
		dieVelocity2 = DieScript2.dieVelocity;
		stationary = (dieVelocity.x == 0f && dieVelocity.y == 0f && dieVelocity.z == 0f &&dieVelocity2.x == 0f && dieVelocity2.y == 0f && dieVelocity2.z == 0f);
    }

	void OnTriggerStay(Collider col)
	{
		//Debug.Log("Triggered");
		if (stationary)
		{
			switch (col.gameObject.name)
			{
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
			switch (col.gameObject.name)
			{
			case "Side 1b":
                currentSide2 = 6;
				break;
			case "Side 2b":
                currentSide2 = 5;
				break;
			case "Side 3b":
                currentSide2 = 4;
				break;
			case "Side 4b":
                currentSide2 = 3;
				break;
			case "Side 5b":
                currentSide2 = 2;
				break;
			case "Side 6b":
                currentSide2 = 1;
				break;
			}
			done = true;
		}
	}

    // void OnTriggerStay(Collider col)
	// {
	// 	//Debug.Log("Triggered");
	// 	if (stationary)
	// 	{
	// 		switch (col.gameObject.name) {
	// 		case "Side 1":
    //             currentSide = 6;
	// 			break;
	// 		case "Side 2":
    //             currentSide = 5;
	// 			break;
	// 		case "Side 3":
    //             currentSide = 4;
	// 			break;
	// 		case "Side 4":
    //             currentSide = 3;
	// 			break;
	// 		case "Side 5":
    //             currentSide = 2;
	// 			break;
	// 		case "Side 6":
    //             currentSide = 1;
	// 			break;
	// 		}
	// 		done = true;
	// 	}
	// }
}
