using UnityEngine;
using System.Collections;

public enum Directions {UP, RIGHT, DOWN, LEFT};

public class MovingBlockerScript : MonoBehaviour {
	public Directions direction = Directions.UP;
	public float movespeed = 8.0f;
	public GameObject lastCollisionObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody2D != null)
		{
			switch (direction)
			{
			case Directions.UP:
				rigidbody2D.velocity = new Vector2(0, movespeed);
				break;
			case Directions.RIGHT:
				rigidbody2D.velocity = new Vector2(movespeed, 0);
				break;
			case Directions.DOWN:
				rigidbody2D.velocity = new Vector2(0, -movespeed);
				break;
			case Directions.LEFT:
				rigidbody2D.velocity = new Vector2(-movespeed, 0);
				break;
			default:
				rigidbody2D.velocity = new Vector2(0, 0);
				break;
			}
		}
		else
		{
			Debug.Log("Can't find a rigid body. Did you forget to add one?");
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		CollisionBehavior(other);
		lastCollisionObject = other.gameObject;
	}


	void OnCollisionStay2D(Collision2D other)
	{
		//Debug.Log("Touching a thing.");
		if (other.collider.GetComponent<MovingBlockerScript>() != null)
		{
			//Debug.Log("It's a wall!");
			//transform.position = new Vector2 (transform.position.x - rigidbody2D.velocity.x, transform.position.y - rigidbody2D.velocity.y);
			//ChangeDirections();

			if (other.gameObject != lastCollisionObject)
			{
				CollisionBehavior(other);
			}
		}
	}


	protected void ChangeDirections()
	{
		switch (direction)
		{
		case Directions.UP:
			direction = Directions.RIGHT;
			break;
		case Directions.RIGHT:
			direction = Directions.DOWN;
			break;
		case Directions.DOWN:
			direction = Directions.LEFT;
			break;
		case Directions.LEFT:
			direction = Directions.UP;
			break;
		default:
			direction = Directions.UP;
			break;
		}
	}

	protected void CollisionBehavior(Collision2D other)
	{
		//Debug.Log("Touching a thing.");
		if (other.collider.GetComponent<PlayerController_Yellow>() == null)
		{
			//Debug.Log("It's a wall!");
			transform.position = new Vector2 (transform.position.x - rigidbody2D.velocity.x * Time.deltaTime, transform.position.y - rigidbody2D.velocity.y * Time.deltaTime);
			ChangeDirections();
		}
	}
}
