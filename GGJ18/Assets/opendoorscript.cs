using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoorscript : MonoBehaviour {

    // Use this for initialization
    private SpriteRenderer thissprite;
    public Sprite changeto;
    public Sprite thisSprite;
    private BoxCollider2D ps;
    private bool open = false;
	void Start () {
        thissprite = GetComponent<SpriteRenderer>();
        ps = gameObject.GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {


	}
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
        print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
        print("Their relative velocity is " + collisionInfo.relativeVelocity);
    }

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if (Input.GetKeyDown(KeyCode.N) && !open  )
        {
            ps.enabled = false;
            thissprite.sprite = changeto;
            open = true;
        }
        else if (Input.GetKeyDown(KeyCode.N) && open)
        {
            // its fine fuck it
            ps.enabled = true;
            thissprite.sprite = thisSprite;
            open = false;
        }
    }
}
