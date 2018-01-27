using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	public GameObject menu;

	public void Activate()
	{
		//Next level stuff
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}