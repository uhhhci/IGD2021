using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonPlayer : MonoBehaviour {
	
	private GameObject cannon;
	private GameObject marker;
	private Vector2 movement;
	
	public float rotationSpeed = 0.05f;
	public int markerRenderingLayer = 0;
	
	private void SwitchInput() {
		string controlScheme = GetComponent<PlayerInput>().defaultControlScheme;
		GetComponent<PlayerInput>().SwitchCurrentControlScheme(controlScheme, Keyboard.current);
	}
	
	void Start() {
		SwitchInput();
		
		cannon = transform.Find("Cannon").gameObject;
		marker = transform.Find("Marker").gameObject;
		
		marker.layer = markerRenderingLayer;
	}
	
	void Update() {
		marker.transform.Translate(-movement.x * rotationSpeed, movement.y * rotationSpeed, 0.0f);
		cannon.transform.LookAt(marker.transform);
	}
	
	private void OnMove(InputValue value) {
		movement = value.Get<Vector2>().normalized;
	}
	
	private void OnMoveDpad(InputValue value) {
		movement = value.Get<Vector2>().normalized;
	}
	
}
