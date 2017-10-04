using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
	public AudioClip clipOpen = null;
	public AudioClip clipLocked = null;
	public float TIME_TOTAL_OPEN = 4;

	public bool locked = true;

	private bool opening = false;
	private Vector3 posInitial;
	private Vector3 posFinal;
	private float timeComplete;

	void Start() {
		posFinal = posInitial = transform.position;
		posFinal.y += 8;
		timeComplete = 0;
	}

    void Update() {
        // If the door is opening and it is not fully raised
		if (opening) {
			timeComplete += Time.deltaTime;
			if (timeComplete >= TIME_TOTAL_OPEN)
				opening = false;
			else {
				if (clipOpen) {
					AudioSource sourcePlayer = Camera.main.GetComponent<AudioSource> ();
					if (sourcePlayer)
						sourcePlayer.PlayOneShot (clipOpen);
				}			
				// Animate the door raising up
				transform.position = Vector3.Lerp (posInitial, posFinal, timeComplete / TIME_TOTAL_OPEN);
			}
		}
    }

    public void OnDoorClicked() {
        // If the door is clicked and unlocked
		if (!locked) {
			if (!opening)
				opening = true;
			// Set the "opening" boolean to true
		} else if (clipLocked) {
			// (optionally) Else
			// Play a sound to indicate the door is locked
			AudioSource sourcePlayer = Camera.main.GetComponent<AudioSource> ();
			if (sourcePlayer)
				sourcePlayer.PlayOneShot(clipLocked);
		}

    }

	public void LockSet(bool bIsNowLocked=false)
    {
		//for now, called by Inventory's method when a new key is picked up
		// You'll need to set "locked" to false here
		locked = bIsNowLocked;
    }

	public virtual void Reset() {
		transform.position = posInitial;
		LockSet (true);
	}
}
