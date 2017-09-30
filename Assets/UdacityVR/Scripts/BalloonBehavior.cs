using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBehavior : MonoBehaviour {
	private float timeComplete;
	private float timeLast;
	private Vector3 positionComplete;
	private Vector3 positionInit;
	private Vector3 positionLast;

	public bool isFree = false;
	public bool isMagic = false;
	public float MAX_DRIFT = 1.0f;
	public float MAX_TIME_DRIFT = 3f;

	// Use this for initialization
	void Start () {
		positionLast = positionComplete = positionInit = transform.localPosition;
		generatePosition ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isFree) {
			timeLast += Time.deltaTime;
			if (timeLast >= timeComplete)
				generatePosition ();
			transform.localPosition = Vector3.Slerp (positionLast, positionComplete, timeLast / timeComplete);
		} else {
			if (transform.localPosition.y > 20) {
				gameObject.SetActive (false);
			}
		}
	}

	//generate new random target position for balloon
	private void generatePosition() {
		timeLast = 0f;
		positionLast = positionComplete;
		//random duration for moving around
		timeComplete = Random.Range(1f, MAX_TIME_DRIFT);
		//random new target position
		positionComplete.x = Random.Range (positionLast.x - MAX_DRIFT, positionLast.x + MAX_DRIFT);
		positionComplete.y = Random.Range (positionLast.y - MAX_DRIFT, positionLast.y + MAX_DRIFT);
		//bound limit how far away it can go from init position
		positionComplete.x = Mathf.Min (Mathf.Max (positionComplete.x, positionInit.x - MAX_DRIFT), positionInit.x + MAX_DRIFT);
		positionComplete.y = Mathf.Min (Mathf.Max (positionComplete.y, positionInit.y - MAX_DRIFT), positionInit.y + MAX_DRIFT);
	}

	//simulate cutting string or resetting it
	public void toggleFreezePosition(bool reset=false) {
		Rigidbody rigidbody = gameObject.GetComponent<Rigidbody> ();
		//http://answers.unity3d.com/questions/238887/can-you-unfreeze-a-rigidbodyconstraint-position-as.html
		if ((rigidbody.constraints & RigidbodyConstraints.FreezePositionY)!=0) {
			rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
			isFree = true;
		}
		if (reset) {
			rigidbody.constraints |= RigidbodyConstraints.FreezePositionY;
			isFree = false;
		}
	}

	//reset position to start, reattach line
	public void resetPosition() {
		gameObject.SetActive (true);
		transform.localPosition = positionInit;
		toggleFreezePosition (true);
	}
}
