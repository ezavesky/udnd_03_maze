using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameBalloon : MonoBehaviour {
	public GameObject containerBalloon;
	public GameObject gamePrize = null;


	//check to see if there was a blue balloon found..
	public void triggerCheck() {
		bool magicFound = false;
		foreach (BalloonBehavior child in transform.GetComponentsInChildren<BalloonBehavior> ()) {
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

	//reset all balloon positions
	public void triggerReset() {
		//Debug.Log ("RESET");
		foreach (BalloonBehavior child in transform.GetComponentsInChildren<BalloonBehavior> ()) {
			child.resetPosition ();
		}
	}


}
