using UnityEngine;
using System.Collections;

public class Ejector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		MoveIt(other);
	}

	void OnTriggerStay2D(Collider2D other)
	{
		MoveIt(other);
	}

	void MoveIt(Collider2D other)
	{
		if (other.rigidbody2D != null)
		{
			float amp = Random.value * 500f + 0.1f;
			Vector2 pushVector = Random.insideUnitCircle;
			
			other.rigidbody2D.AddForce(pushVector * amp);
			Debug.Log(pushVector.ToString());
			Debug.Log(amp.ToString());
			Debug.Log(other.gameObject.ToString());
			Debug.Log(other.rigidbody2D.velocity.ToString());
			
		}
	}
}
