using UnityEngine;
using System.Collections;

public class PlayerController_Yellow : MonoBehaviour {

	public AudioSource jumpingSound;
	public AudioSource landingSound;
	public AudioSource attackingSound;
	
	public float vert = 0;
	public float horiz = 0;
	public bool doAct = false;
	
	float movespeed = 128.0f;
	
	float dt = 0;
	float attackCooldown = 1.5f;
	float attackCooldownTimer = 0.0f;
	
	bool selected = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Get the values from the input so we can use it soon.
		dt = Time.deltaTime;
		horiz = Input.GetAxis("Horizontal");
		vert = Input.GetAxis("Vertical");
		doAct = Input.GetButtonDown("Fire2");
		
		//Update any countdown timers before trying to do things that depend on them.
		if (attackCooldownTimer > 0)
		{
			attackCooldownTimer -= dt;
		}
		
		//Move around, jump, attaack, etc. Basically make use of the input values now.
		if (rigidbody2D != null)
		{
			rigidbody2D.velocity = new Vector2(horiz * movespeed * dt, vert * movespeed * dt);
		}
		
	}
}
