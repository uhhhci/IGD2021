using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonPlayer : MonoBehaviour {
	
	private GameObject cannon;
	private bool shooting;
	private float lastShotTimer;
	
	public GameObject marker = null;
	public Camera camera = null;
	public GameObject bullet = null;
	public float bulletSpeed = 15.0f;
	public float cooldown = 1.0f;
	
	private void SwitchInput() {
		string controlScheme = GetComponent<PlayerInput>().defaultControlScheme;
		
		GetComponent<PlayerInput>().SwitchCurrentControlScheme(controlScheme, Keyboard.current);
	}
	
	private void LookAtTarget() {
		if (marker != null && camera != null) {
			Vector3 markerPos = camera.WorldToScreenPoint(marker.transform.position);
			
			markerPos.z = Mathf.Abs(camera.transform.position.x);
			
			Vector3 target = camera.ScreenToWorldPoint(markerPos);
			
			cannon.transform.LookAt(target);
		}
	}
	
	private void CheckShooting() {
		if (shooting && bullet != null && lastShotTimer >= cooldown) {
			Vector3 spawnPoint = cannon.transform.position + cannon.transform.forward;
			GameObject instance = Instantiate(bullet, spawnPoint, Quaternion.identity);
			Rigidbody rb = instance.GetComponent<Rigidbody>();
			
			rb.velocity = cannon.transform.forward * bulletSpeed;
			shooting = false;
			lastShotTimer = 0.0f;
		}
	}
	
	void Start() {
		SwitchInput();
		
		cannon = transform.Find("Cannon").gameObject;
		lastShotTimer = cooldown;
	}
	
	void Update() {
		LookAtTarget();
		CheckShooting();
		
		lastShotTimer += Time.deltaTime;
	}
	
	void OnSouthPress() {
		shooting = true;
	}
	
	void OnSouthRelease() {
		shooting = false;
	}
	
}
