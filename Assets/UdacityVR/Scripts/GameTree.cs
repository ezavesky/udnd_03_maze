using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTree : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text objText = transform.gameObject.GetComponent<Text> ();		//get text on this object
		if (objText) {
			objText.text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void triggerCharacter(string newLetter) {
		Text objText = transform.gameObject.GetComponent<Text> ();		//get text on this object
		if (!objText) {
			Debug.LogError ("Can't retrieve GUIText object from current object!");
			return;
		}
		if (newLetter.Length == 0)
			objText.text = "";
		else
			objText.text = objText.text + newLetter;
	}
}
