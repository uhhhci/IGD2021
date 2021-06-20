using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonStandoff : MiniGame {
	
	private bool running;
	private int scoreSolo, scoreTeam;
	private GameObject activeWall;
	
	public CannonPlayer p1, p2, p3, p4;
	public GameObject[] wallTypes;
	
	private void SpawnWall() {
		if (wallTypes != null && wallTypes.Length > 0) {
			int i = Random.Range(0, wallTypes.Length);
			GameObject wall = wallTypes[i];
			
			activeWall = Instantiate(wall);
		}
	}
	
	private void CheckEndOfGame() {
		if (!running) {
			return;
		}
		
		int remainingBlocks = activeWall.GetComponentsInChildren<Transform>().Length - 1;
		int[] firstPlace, secondPlace;
		int[] empty = {};
		
		if (remainingBlocks == 0) {
			if (scoreSolo > scoreTeam) {
				firstPlace = new int[]{1};
				secondPlace = new int[]{2, 3, 4};
			} else if (scoreTeam > scoreSolo) {
				firstPlace = new int[]{2, 3, 4};
				secondPlace = new int[]{1};
			} else {
				firstPlace = new int[]{1, 2, 3, 4};
				secondPlace = new int[]{};
			}
			
			MiniGameFinished(firstPlace, secondPlace, empty, empty);
			
			running = false;
		}
	}
	
	private void InitAi() {
		bool aiP1 = PlayerPrefs.GetString("Player1_AI").Equals("True");
		bool aiP2 = PlayerPrefs.GetString("Player2_AI").Equals("True");
		bool aiP3 = PlayerPrefs.GetString("Player3_AI").Equals("True");
		bool aiP4 = PlayerPrefs.GetString("Player4_AI").Equals("True");
		
		if (aiP1) {
			PlayerInput input = p1.GetComponent<PlayerInput>();
			PlayerInput inputMarker = p1.marker.GetComponent<PlayerInput>();
			
			Destroy(input);
			Destroy(inputMarker);
			
			p1.SetAiControlled(true);
		}
		
		if (aiP2) {
			PlayerInput input = p2.GetComponent<PlayerInput>();
			PlayerInput inputMarker = p2.marker.GetComponent<PlayerInput>();
			
			Destroy(input);
			Destroy(inputMarker);
			
			p2.SetAiControlled(true);
		}
		
		if (aiP3) {
			PlayerInput input = p3.GetComponent<PlayerInput>();
			PlayerInput inputMarker = p3.marker.GetComponent<PlayerInput>();
			
			Destroy(input);
			Destroy(inputMarker);
			
			p3.SetAiControlled(true);
		}
		
		if (aiP4) {
			PlayerInput input = p4.GetComponent<PlayerInput>();
			PlayerInput inputMarker = p4.marker.GetComponent<PlayerInput>();
			
			Destroy(input);
			Destroy(inputMarker);
			
			p4.SetAiControlled(true);
		}
	}
	
	void Start() {
		running = true;
		
		SpawnWall();
		InitAi();
	}
	
	void Update() {
		CheckEndOfGame();
	}
	
	public void ScoreForSolo() {
		scoreSolo++;
	}
	
	public void ScoreForTeam() {
		scoreTeam++;
	}
	
	public override string getDisplayName() {
		return "Cannon standoff";
	}
	
	public override string getSceneName() {
		return "CannonStandoff";
	}

	public override MiniGameType getMiniGameType() {
		return MiniGameType.singleVsTeam;
	}
	
}
