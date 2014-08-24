using UnityEngine;
using System.Collections;

public class DoNotDestroyThisObject : MonoBehaviour {

	void Awake() 
	{
		DontDestroyOnLoad(gameObject);
	}
}
