using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlock : MonoBehaviour {
	
	private bool scored;
	
	public float timeToLiveAfterScore = 3.0f;
	
	void Start() {
		;
	}
	
	void Update() {
		;
	}
	
	void OnCollisionEnter(Collision collision) {
		GameObject collider = collision.gameObject;
		
		if (!scored && collider != null && collider.tag == "Floor") {
			float posX = transform.position.x;
			
			scored = true;
			
			if (posX < 0) {
				Debug.Log("Point for solo player");
			} else if (posX > 0) {
				Debug.Log("Point for team");
			} else {
				scored = false;
			}
			
			if (scored) {
				Destroy(gameObject, timeToLiveAfterScore);
			}
		}
	}
	
}
