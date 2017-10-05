using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameBalloon : MonoBehaviour, IGameInterface {
	public GameObject containerBalloon;
	public GameObject gamePrize = null;

	private BalloonBehavior[] balloonSet;

	void Start() {
		//grab once because we'll be deactivating some components
		balloonSet = transform.GetComponentsInChildren<BalloonBehavior>();
	}

	//check to see if there was a blue balloon found from broadcast message
	public void triggerCheck() {
		bool magicFound = false;
		foreach (BalloonBehavior child in balloonSet) {
			//Debug.Log ("CHILD: " + child.isFree + ", magic:" + child.isMagic);
			if (child.isMagic && !child.isFree) 
				magicFound = true;
		}
		if (!magicFound) {
			//Debug.Log ("NO MAGIC");
			if (gamePrize)
				gamePrize.SetActive (true);
		}
	}

	//balloon was cut, broadcasted this message
	public void triggerCut() {
		AudioSource objSource = gameObject.GetComponent<AudioSource> ();
		if (objSource)
			objSource.Play();
	}


	//reset all balloon positions
	public void Reset() {
		//Debug.Log ("RESET");
		foreach (BalloonBehavior child in balloonSet) {
			child.resetPosition ();
		}
	}


}
