using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadlevel : MonoBehaviour {

    public GameObject menu;
    public GameObject levelmenu;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void ShowLevels()
    {
        menu.active = false;
        levelmenu.active = true;

    }

    public void ShowMenu()
    {
        menu.active = true;
        levelmenu.active = false;

    }
}
