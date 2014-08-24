//This script uses some copypasta from SmoothFollow2D of the Unity Standard package.

using UnityEngine;
using System.Collections;

public class FollowSelected : MonoBehaviour {

	public GameObject theGameController;
	public GameController gcscript;

	public GameObject target;
	public float smoothTime = 0.3f;
	private Transform thisTransform;
	private Vector2 velocity;

	// Use this for initialization
	void Start () {
		if (theGameController != null)
		{
			thisTransform = transform;
			gcscript = theGameController.GetComponent<GameController>();
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gcscript != null)
		{
			if (gcscript.selectedCharacter != target)
			{
				target = gcscript.selectedCharacter;
			}
		}
		float tempx = velocity.x;
		float tempy = velocity.y;
		float temptransx = Mathf.SmoothDamp( thisTransform.position.x, 
		                                            target.transform.position.x, ref tempx, smoothTime);
		float temptransy = Mathf.SmoothDamp( thisTransform.position.y, 
		                                            target.transform.position.y, ref tempy, smoothTime);
		thisTransform.position = new Vector3(temptransx, temptransy, thisTransform.position.z);
		velocity = new Vector2(tempx, tempy);
	}
}
