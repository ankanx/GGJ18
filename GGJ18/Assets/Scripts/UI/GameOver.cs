using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	
	public void Quit() {
		//Application.Quit();
	}
	
	public void Retry () {
		//Debug.Log("Retry");
		//Application.LoadLevel(Application.loadedLevel);
	}

	public void Menu() {
		//Debug.Log("TODO Menu() in GameOver script.");
		 //SceneManager.LoadScene("Menues");
	}

}
