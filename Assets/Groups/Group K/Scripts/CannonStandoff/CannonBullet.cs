using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour {
	
	public float timeToLive = 5.0f;
	
	void Start() {
		Destroy(gameObject, timeToLive);
	}
	
	void Update() {
		;
	}
	
}
