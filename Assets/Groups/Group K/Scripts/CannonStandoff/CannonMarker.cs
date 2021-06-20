using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonMarker : MonoBehaviour {
	
	private Vector2 movement;
	
	public float speed = 3.0f;
	
	void Start() {
		;
	}
	
	void Update() {
		float movementHorizontal = movement.x * speed * Time.deltaTime;
		float movementVertical = movement.y * speed * Time.deltaTime;
		
		transform.Translate(movementHorizontal, movementVertical, 0.0f);
	}
	
	public void Move(Vector2 movement) {
		this.movement = movement;
	}
	
}
