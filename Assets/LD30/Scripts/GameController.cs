using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject selectedCharacter;
	public GameObject selectableChar1;
	public GameObject selectableChar2;
	public GameObject selectableChar3;

	//public System.Collections.Generic.List<GameObject> selectableCharacters = new System.Collections.Generic.List<GameObject>(3);

	public bool doCamSwitch;

	// Use this for initialization
	void Start () {
		if (selectedCharacter == null && selectableChar1 != null)
		{
			selectableChar1 = selectableChar1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		doCamSwitch = Input.GetButtonDown("Fire2");

		if (doCamSwitch)
		{
			if (selectedCharacter == selectableChar1 && selectableChar2 != null)
			{
				selectedCharacter = selectableChar2;
			}

			else if (selectedCharacter == selectableChar2 && selectableChar1 != null)
			{
				selectedCharacter = selectableChar1;
			}
			//TODO: Tweak this so that it can support any number of characters, not just two.
		}
	}
}
