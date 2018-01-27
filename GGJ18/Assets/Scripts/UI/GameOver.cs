using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	
	public void Quit() {
		Application.Quit();
	}
	
	public void Retry () {
		Application.LoadLevel(Application.loadedLevel);
	}

	public void Menu() {
        SceneManager.LoadScene(1);
    }

}
