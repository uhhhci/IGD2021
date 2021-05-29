using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonPlayer : MonoBehaviour {
	
	private GameObject cannon;
	private bool shooting;
	
	public GameObject marker = null;
	public Camera camera = null;
	public GameObject bullet = null;
	public float bulletSpeed = 15.0f;
	
	private void SwitchInput() {
		string controlScheme = GetComponent<PlayerInput>().defaultControlScheme;
		
		GetComponent<PlayerInput>().SwitchCurrentControlScheme(controlScheme, Keyboard.current);
	}
	
	void Start() {
		SwitchInput();
		
		cannon = transform.Find("Cannon").gameObject;
	}
	
	void Update() {
		if (marker != null && camera != null) {
			Vector3 markerPos = camera.WorldToScreenPoint(marker.transform.position);
			
			markerPos.z = Mathf.Abs(camera.transform.position.x);
			
			Vector3 target = camera.ScreenToWorldPoint(markerPos);
			
			cannon.transform.LookAt(target);
		}
		
		if (shooting && bullet != null) {
			Vector3 spawnPoint = cannon.transform.position + cannon.transform.forward;
			GameObject instance = Instantiate(bullet, spawnPoint, Quaternion.identity);
			Rigidbody rb = instance.GetComponent<Rigidbody>();
			
			rb.velocity = cannon.transform.forward * bulletSpeed;
			shooting = false;
		}
	}
	
	void OnSouthPress() {
		shooting = true;
	}
	
}
