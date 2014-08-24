using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour {
	bool started = false;


	void Update()
	{
		if (started && audio != null && !audio.isPlaying)
		{
			Cleanup();
		}
	}

	public void Activate()
	{
		started = true;

		if (audio != null)
		{
			audio.Play();
			Destroy(rigidbody2D);
			Destroy(gameObject.GetComponents<MovingBlockerScript>()[0]);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void Cleanup()
	{
		Destroy(gameObject);
	}
}
