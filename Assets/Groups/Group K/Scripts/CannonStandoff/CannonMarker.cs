using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonMarker : MonoBehaviour {
	
	private Vector2 movement;
	
	public float rotationSpeed = 0.05f;
	
	private void SwitchInput() {
		string controlScheme = GetComponent<PlayerInput>().defaultControlScheme;
		
		GetComponent<PlayerInput>().SwitchCurrentControlScheme(controlScheme, Keyboard.current);
	}
	
	void Start() {
		SwitchInput();
	}
	
	void Update() {
		transform.Translate(-movement.x * rotationSpeed, movement.y * rotationSpeed, 0.0f);
	}
	
	private void OnMove(InputValue value) {
		movement = value.Get<Vector2>().normalized;
	}
	
	private void OnMoveDpad(InputValue value) {
		movement = value.Get<Vector2>().normalized;
	}
	
}
