using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	
	public void Quit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    public void Retry () {
		Application.LoadLevel(Application.loadedLevel);
	}

	public void Menu() {
        SceneManager.LoadScene(1);
    }

}
