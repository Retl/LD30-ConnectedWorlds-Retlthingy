//I should really use an Interface for this sort of thing, but I don't want to risk the time to go relearn it. So we're gonna have some redundant code.
using UnityEngine;
using System.Collections;

public class ActivateMe : MonoBehaviour {
	Vector3	startingPosition;

	// Use this for initialization
	void Start () 
	{
		startingPosition = transform.position;
	}

	// Use this for initialization
	public void Activate()
	{
		if (audio != null)
		{
			audio.Play();
		}
		transform.position = startingPosition + (transform.up * 3);
	}
	
	public void DeActivate()
	{
		if (audio != null)
		{
			audio.Play();
		}
		transform.position = startingPosition;
	}
}
