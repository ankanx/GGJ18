using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public Transform[] patrolpoints;
    int currentPoint;
    public float speed = 0.5f;
    public float timestill = 2.0f;
    public float sight = 3f;
    public float force;

    public LayerMask detectWhat;

    protected bool dead = false;

    Animator anim;

    public AudioClip audio_walk;

    public AudioSource audio_source;

    // Use this for initialization
    void Start () {

        for(int i = 0; i < patrolpoints.Length; i++)
        {
            if(patrolpoints[i] == null)
            {
                patrolpoints[i] = gameObject.transform;
            }
        }
        anim = GetComponent<Animator>();
        StartCoroutine("Patrol");
        anim.SetBool("walking", true);
        anim.SetBool("dead", false);
        Physics2D.queriesStartInColliders = false;

    }

    // Update is called once per frame
    void Update ()
    {
        if (dead == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.right, sight, detectWhat);
            if (hit.collider != null && hit.collider.tag == "Player")
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * force + (hit.collider.transform.position - transform.position) * force);
            }

        }

            
	}

    IEnumerator Patrol ()
    {
        while (dead == false)
        {


            if (transform.position.x == patrolpoints[currentPoint].position.x)
            {
                currentPoint++;
                anim.SetBool("walking", false);
                yield return new WaitForSeconds(timestill);
                anim.SetBool("walking", true);
            }

            if (currentPoint >= patrolpoints.Length)
            {
                currentPoint = 0;
            }

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(patrolpoints[currentPoint].position.x, transform.position.y), speed);

            //audio_source.PlayOneShot(audio_walk, 0.03f);

            if (transform.position.x > patrolpoints[currentPoint].position.x)
                transform.localScale = new Vector3(-1, 1, 1);
            else if (transform.position.x < patrolpoints[currentPoint].position.x)
                transform.localScale = Vector3.one;

            yield return null;
            // in case we want to do it with seconds
            //yield return new WaitForSeconds(4f);

        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Pesticide")
        {
            dead = true;
            anim.SetBool("dead", true);
            this.tag = "Untagged";
            Destroy(this.gameObject, 2f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 

        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * sight);
    }

}
