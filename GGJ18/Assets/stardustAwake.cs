using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stardustAwake : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        GetComponent<Rigidbody2D>().AddTorque(Random.Range(-200.0f, 200.0f));
    }
	
}
