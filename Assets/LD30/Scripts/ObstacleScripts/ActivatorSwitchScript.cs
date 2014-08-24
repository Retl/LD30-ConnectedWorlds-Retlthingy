//I should really use an Interface for this sort of thing, but I don't want to risk the time to go relearn it. So we're gonna have some redundant code.
using UnityEngine;
using System.Collections;

public class ActivatorSwitchScript : MonoBehaviour {
	public GameObject activateThingy;
	public ActivateMe activateMe;
	public DestroyMe destroyMe;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (activateThingy != null)
		{
			activateMe = activateThingy.GetComponent<ActivateMe>();
			destroyMe = activateThingy.GetComponent<DestroyMe>();
			
		}
		
		bool isPlayer = (other.gameObject.GetComponent<PlayerController_Blue>() != null || other.gameObject.GetComponent<PlayerController_Yellow>() != null );
		
		if (activateMe != null && isPlayer)
		{
			activateMe.Activate();
		}

		if (destroyMe != null && isPlayer)
		{
			destroyMe.Activate();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		
		if (activateThingy != null)
		{
			activateMe = activateThingy.GetComponent<ActivateMe>();
			
		}
		
		bool isPlayer = (other.gameObject.GetComponent<PlayerController_Blue>() != null || other.gameObject.GetComponent<PlayerController_Yellow>() != null );
		
		if (activateMe != null && isPlayer)
		{
			activateMe.DeActivate();
		}
	}
}
