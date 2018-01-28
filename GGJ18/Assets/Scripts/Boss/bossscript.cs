using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossscript : MonoBehaviour {

    public Transform[] spots;
    public float speed = 0.5f;
    public GameObject fart;

    public float fartTime = 10.0f;

    public Transform[] holes;

    public float life = 300.0f;

    GameObject player;
    Vector3 playerPos;
    bool dead = false;

    //public Sprite[] sprites;
    public bool vulnerable = true;

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("boss");
        anim.SetBool("angery", false);
        anim.SetBool("sad", false);
    }

    // Update is called once per frame
    void Update () {
        Debug.Log(life);

        if (transform.position.x < player.transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        if (life < 0)
        {
            dead = true;
            //anim.SetBool("dead", true);
            Debug.Log("YOU WOOOONNNNNN");
            anim.SetBool("sad", true);

        }
    }

    IEnumerator boss()
    {
        while (true)
        {
            //FIRST ATTACK

            while (transform.position.x != spots[0].position.x)
            {
                anim.SetBool("sad", false);

                transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[0].position.x, transform.position.y), speed);

                yield return null;
            }

            transform.localScale = new Vector2(-1, 1);
            
            yield return new WaitForSeconds(1f);

            int i = 0;
            while (i < holes.Length)
            {

                GameObject bullet = (GameObject)Instantiate(fart, holes[Random.Range(0, holes.Length)].position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * 5;

                Destroy(bullet, fartTime);

                i++;
                yield return new WaitForSeconds(.7f);
            }


            //SECOND ATTACK
            //GetComponent<Rigidbody2D>().isKinematic = true;
            while (transform.position != spots[2].position)
            {
                anim.SetBool("sad", false);

                transform.position = Vector2.MoveTowards(transform.position, spots[2].position, speed);

                yield return null;
            }

            

            yield return new WaitForSeconds(1f);
            //GetComponent<Rigidbody2D>().isKinematic = false;

            while (transform.position.x != playerPos.x)
            {
                playerPos = player.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPos.x, transform.position.y), speed);

                yield return null;
            }

            this.tag = "Untagged";
            anim.SetBool("angery", true);
            vulnerable = false;
            yield return new WaitForSeconds(3);
            this.tag = "deadly";
            anim.SetBool("angery", false);
            vulnerable = true;

            //THIRD ATTACK
            Transform temp;
            if (transform.position.x > player.transform.position.x)
                temp = spots[1];
            else
                temp = spots[0];

            while (transform.position.x != temp.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(temp.position.x, transform.position.y), speed);
                yield return null;
            }
            

            yield return null;

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Pesticide") && (vulnerable == true))
        {
            Debug.Log("HIT");
            //Destroy(this.gameObject, 0.1f);
            life = life - 30;
            anim.SetBool("sad", true);

        }
    }

}
