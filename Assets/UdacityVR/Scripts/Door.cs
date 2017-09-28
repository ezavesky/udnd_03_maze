using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
	public AudioClip clipOpen;
	public AudioClip clipLocked;
	private bool locked = true;
	private bool opening = false;

    void Update() {
        // If the door is opening and it is not fully raised
            // Animate the door raising up
    }

    public void OnDoorClicked() {
        // If the door is clicked and unlocked
            // Set the "opening" boolean to true
        // (optionally) Else
            // Play a sound to indicate the door is locked
    }

    public void Unlock()
    {
        // You'll need to set "locked" to false here
    }
}
