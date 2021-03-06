﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject selectedCharacter;
	public GameObject selectableChar1;
	public GameObject selectableChar2;
	public GameObject selectableChar3;

	public AudioSource sfxPlayer;

	//public System.Collections.Generic.List<GameObject> selectableCharacters = new System.Collections.Generic.List<GameObject>(3);

	public bool doCamSwitch;
	public bool gameOver = false;

	public float timeRemaining = 60.0f;

	// Use this for initialization
	void Start () {
		sfxPlayer = gameObject.GetComponent<AudioSource>();
		if (selectedCharacter == null && selectableChar1 != null)
		{
			selectedCharacter = selectableChar1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Always decrement the timer first.
		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0)
		{
			timeRemaining = 0;
			if (!gameOver)
			{
				gameOver = true;
			}
		}

		doCamSwitch = Input.GetButtonDown("Fire2");


		if (doCamSwitch)
		{
			bool switched = false;
			if (selectedCharacter == selectableChar1 && selectableChar2 != null)
			{
				selectedCharacter = selectableChar2;
				switched = true;
			}

			else if (selectedCharacter == selectableChar2 && selectableChar1 != null)
			{
				selectedCharacter = selectableChar1;
				switched = true;
			}

			if (switched)
			{
				sfxPlayer.Play();
			}
			//TODO: Tweak this so that it can support any number of characters, not just two.
		}

		if (Input.GetButtonDown("Quit"))
		{
			Application.Quit();
		}

		if (gameOver)
		{
			StartCoroutine(WaitABit());
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	
	void OnGUI () {
		GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Time remaining: " + timeRemaining.ToString("f"));
	}

	public void AdvanceLevel()
	{
		if (Application.loadedLevel < Application.levelCount - 1)
		{
			Application.LoadLevel(Application.loadedLevel + 1);
		}
		else
		{
			Application.LoadLevel(0);
		}
	}

	IEnumerator WaitABit()
	{
		yield return new WaitForSeconds(1);
	}
}
