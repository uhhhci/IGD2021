using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonPlayer : MonoBehaviour {
	
	private GameObject cannon;
	private GameObject marker;
	
	private float pitch, yaw;
	private Vector2 movement;
	
	private float rotationSpeed = 0.05f;
	
	void Start() {
		cannon = transform.Find("Cannon").gameObject;
		marker = transform.Find("Marker").gameObject;
	}
	
	void Update() {
		marker.transform.Translate(-movement.x * rotationSpeed, movement.y * rotationSpeed, 0.0f);
		cannon.transform.LookAt(marker.transform);
	}
	
	private void OnMove(InputValue value) {
		movement = value.Get<Vector2>();
	}
	
	private void OnMoveDpad(InputValue value) {
		movement = value.Get<Vector2>();
	}
	
}
