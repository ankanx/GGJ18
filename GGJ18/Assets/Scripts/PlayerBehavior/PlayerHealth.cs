using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public int takeDamage = 25;
    private long msec = 0;
    private DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private bool damaged = false;
	public GameObject GameOver;
	private LivesManager livesLeft;

	public LevelManager levelManager;

    public AudioClip audio_gainlife;
    public AudioClip audio_respawn;
    public AudioClip audio_takedamage;
    public AudioClip audio_death;

    public AudioSource audS;
    
    void Awake ()
    {
        currentHealth = startingHealth;
	    TakeDamage(0);
        msec = 0;
		levelManager = FindObjectOfType<LevelManager> ();
		livesLeft = FindObjectOfType<LivesManager> ();
    }

    void Update ()
    {
	if (damaged) {
		this.TakeDamage(takeDamage);	
	}
    }

    public void GainLife(int amount)
    {
        audS.PlayOneShot(audio_gainlife, 0.4f);
        currentHealth += amount;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int amount)
    {
         if (amount != 0)
            audS.PlayOneShot(audio_takedamage, 0.01f); 

        long now = Convert.ToInt64((DateTime.Now - epoch).TotalMilliseconds);
	    if (msec + 500 > now)
		    return;

        msec = now;
        currentHealth -= amount;

	if (currentHealth < 0) {
			if (livesLeft.DecreaseLives ()) {
				ResetHealth ();
				levelManager.RespawnPlayer ();
			} else {
				Death ();
			}
	} 
		healthSlider.value = currentHealth;
    }



    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "deadly")
        {
		this.damaged = true;
		this.TakeDamage(takeDamage);
	    }
    }

	void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "deadly")
        {
		this.damaged = false;

	    }

    }

       public void Death() {
        audS.PlayOneShot(audio_death, 0.6f);
        gameObject.GetComponent<InputScript>().enabled = false;
        GameOver.SetActive(true);
    }

	public void ResetHealth(){
        audS.PlayOneShot(audio_respawn, 0.6f);
        currentHealth = 100;
		healthSlider.value = currentHealth;
	}

}
