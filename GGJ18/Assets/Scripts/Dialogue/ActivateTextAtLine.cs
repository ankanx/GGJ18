using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;

    public int startingLine;
    public int endLine;

    public TextBoxManager tbm;

    public bool destrouWhenActivated;

	// Use this for initialization
	void Start () {
        tbm = FindObjectOfType<TextBoxManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            tbm.ReloadScript(theText);
            tbm.currentLine = startingLine;
            tbm.endAtLine = endLine;
            tbm.EnableTextBox();

            if (destrouWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }
}
