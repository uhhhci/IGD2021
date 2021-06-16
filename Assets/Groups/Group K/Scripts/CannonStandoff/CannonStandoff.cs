using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonStandoff : MiniGame {
	
	public GameObject[] wallTypes;
	
	private void SpawnWall() {
		if (wallTypes != null && wallTypes.Length > 0) {
			int i = Random.Range(0, wallTypes.Length);
			GameObject wall = wallTypes[i];
			
			Instantiate(wall);
		}
	}
	
	void Start() {
		SpawnWall();
	}
	
	void Update() {
		;
	}
	
	public void ScoreForSolo() {
		Debug.Log("Score for solo player");
	}
	
	public void ScoreForTeam() {
		Debug.Log("Score for team");
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
