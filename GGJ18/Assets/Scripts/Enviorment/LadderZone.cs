using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderZone : MonoBehaviour {

	private InputScript player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<InputScript> ();
	}
	

	void OnTriggerEnter2D (Collider2D other){
		if (other.name == "Player") {
			player.onLadder = true;
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.name == "Player") {
			player.onLadder = false;
		}
	}
}
