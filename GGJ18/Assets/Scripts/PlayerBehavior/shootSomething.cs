using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSomething : MonoBehaviour {

    public GameObject projectile;
    public Vector2 velocity;
    bool canShoot = true;
    public float fartTime = 1.0f;
    
    //public Vector2 offset = new Vector2(-4.842f, -2.456f);
    public Vector2 offset = new Vector2(0.4f, 0.1f);
    public float cooldown = 0.5f;

    protected Vector3 vectorminus = new Vector3(-1, 1, 1); 

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    { 
        if (Input.GetKeyDown(KeyCode.M) && canShoot)
        {
            GameObject go = (GameObject) Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
            //go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
            Vector3 localScaleGo = go.transform.localScale;

            if (transform.localScale.x < 0)
            {
                localScaleGo.x = localScaleGo.x * (-1);
                go.transform.localScale = localScaleGo;
            }

            Destroy(go, fartTime);

            StartCoroutine(CanShoot());
        }

		
	}

    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}
