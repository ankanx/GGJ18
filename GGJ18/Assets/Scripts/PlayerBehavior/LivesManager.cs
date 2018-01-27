using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour {
	public static int lives;
	public static int startingLives = 3;

	static Text text;

	void Start(){

		text = GetComponent<Text> ();

		lives = startingLives;
	}
		
	void Update(){
		text.text = "" + lives;
	}


	public bool DecreaseLives(){
		lives--;
		text.text = "" + lives;
		if (lives <= 0) {
			return false;
		} else {
			return true;
		}
	}

	public void AddLives(int amount){
		lives += amount;
		text.text = "" + lives;
	}

	public void Reset(){
		lives = startingLives;
		text.text = "" + lives;
	}
}
