using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTree : MonoBehaviour, IGameInterface {
	public GameObject gamePrize = null;

	private Color colorInitial;

	// Use this for initialization
	void Start () {
		Text objText = transform.gameObject.GetComponent<Text> ();		//get text on this object
		if (objText) {
			objText.text = "";
			colorInitial = objText.color;
		}
	}

	public void triggerCharacter(string newLetter) {
		Text objText = transform.gameObject.GetComponent<Text> ();		//get text on this object
		if (!objText) {
			Debug.LogError ("Can't retrieve GUIText object from current object!");
			return;
		}
		if (newLetter.Length == 0)
			objText.text = "";
		else {
			objText.text = objText.text + newLetter;
			AudioSource objSource = gameObject.GetComponent<AudioSource> ();
			if (objSource)
				objSource.Play();
		}
		
		if (objText.text == "BANANA") {
			if (gamePrize)
				gamePrize.SetActive (true);
			objText.color = Color.green;
		} else {
			objText.color = colorInitial;
		}
	}

	public void Reset() {
		triggerCharacter ("");
	}
}
