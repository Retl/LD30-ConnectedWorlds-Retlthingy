using UnityEngine;
using System.Collections;

public class PlayerController_Blue : MonoBehaviour {

	public GameObject theGameController;
	public GameController gcscript;

	public AudioClip jumpingSound;
	public AudioClip landingSound;
	public AudioClip attackingSound;

	public float vert = 0;
	public float horiz = 0;
	public bool doJump = false;
	public bool doAct = false;

	float movespeed = 128.0f;
	float jumpSpeed = 9.0f;

	float dt = 0;
	float attackCooldown = 1.5f;
	float attackCooldownTimer = 0.0f;

	bool selected = false;
	int canJump = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Get the values from the input so we can use it soon.
		dt = Time.deltaTime;
		horiz = Input.GetAxis("Horizontal");
		vert = Input.GetAxis("Vertical");
		doJump = Input.GetButtonDown("Fire1");
		doAct = Input.GetButtonDown("Fire2");

		//Update any countdown timers before trying to do things that depend on them.
		if (attackCooldownTimer > 0)
		{
			attackCooldownTimer -= dt;
		}

		//Get a reference to the GameController script in the GameController object.
		if (theGameController != null)
		{
			gcscript = theGameController.GetComponent<GameController>();
			
		}
		else
		{
			Debug.Log("ERROR: Couldn't get a reference to the GameController.");
		}
		
		if (gcscript != null)
		{
			//Am I selected?
			if (gcscript.selectedCharacter == gameObject)
			{
				//Move around, jump, attaack, etc. Basically make use of the input values now.
				if (rigidbody2D != null)
				{
					//Move around, jump, attaack, etc. Basically make use of the input values now.
					if (rigidbody2D != null)
					{
						rigidbody2D.velocity = new Vector2(horiz * movespeed * dt, rigidbody2D.velocity.y);
					}
					
					if (doJump && canJump > 0)
					{
						rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
					}
				}
			}
		}
		else
		{
			Debug.Log("ERROR: Got a reference to the GameController, but not the script it should be hosting.");
		}
	
	}
}
