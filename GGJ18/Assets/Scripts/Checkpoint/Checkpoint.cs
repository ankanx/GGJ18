using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public LevelManager levelManager;
    // Use this for initialization
    void Start () {
        levelManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            levelManager.currentCheckpoint = gameObject;
            GetComponent<SpriteRenderer>().color = new Color(0.388235229f, 0.3372549f, 1f);
        }
    }
}
