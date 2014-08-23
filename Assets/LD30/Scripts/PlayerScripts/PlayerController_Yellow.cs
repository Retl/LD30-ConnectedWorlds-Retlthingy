using UnityEngine;
using System.Collections;

public class PlayerController_Yellow : MonoBehaviour {

	public GameObject theGameController;
	public GameController gcscript;

	public AudioSource jumpingSound;
	public AudioSource landingSound;
	public AudioSource attackingSound;

	public float vert = 0;
	public float horiz = 0;
	public bool doAct = false;
	
	float movespeed = 256.0f;
	
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
					rigidbody2D.velocity = new Vector2(horiz * movespeed * dt, vert * movespeed * dt);
					if (rigidbody2D.velocity.magnitude > 0)
					{
						transform.rotation = Quaternion.Euler(0f, 0f, ( Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * Mathf.Rad2Deg) - 90);
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
