using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlock : MonoBehaviour {
	
	private CannonStandoff game;
	private bool scored;
	
	public float timeToLiveAfterScore = 3.0f;
	
	void Start() {
		GameObject manager = GameObject.Find("GameManager");
		
		if (manager != null) {
			game = manager.GetComponent<CannonStandoff>();
		}
	}
	
	void Update() {
		;
	}
	
	void OnCollisionEnter(Collision collision) {
		GameObject collider = collision.gameObject;
		
		if (!scored && collider != null && collider.tag == "Floor") {
			float posX = transform.position.x;
			
			scored = true;
			
			if (game != null) {
				if (posX < 0) {
					game.ScoreForSolo();
				} else if (posX > 0) {
					game.ScoreForTeam();
				} else {
					//Neither side gets a point I guess?
				}
			}
			
			Destroy(gameObject, timeToLiveAfterScore);
		}
	}
	
	public bool HasScored() {
		return scored;
	}
	
}
