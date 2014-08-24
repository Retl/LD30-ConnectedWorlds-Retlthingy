using UnityEngine;
using System.Collections;

public class GatewayLevelAdvance : MonoBehaviour {
	public GameObject gameController;
	public GameController gameControllerScript;

	void OnTriggerEnter2D(Collider2D other)
	{

		if (gameController != null)
		{
			gameControllerScript = gameController.GetComponent<GameController>();

		}

		bool isPlayer = (other.gameObject.GetComponent<PlayerController_Blue>() != null || other.gameObject.GetComponent<PlayerController_Yellow>() != null );

		if (gameControllerScript != null && isPlayer)
		{
			gameControllerScript.AdvanceLevel();
		}
	}
}
