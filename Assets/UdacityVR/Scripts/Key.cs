using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
	public GameObject effectPrefab = null;
	public AudioClip clipAction = null;
	public Inventory objInventory = null;

	private Quaternion rotationInit;
	private const int ROTATE_SEC_COMPLETE = 4;

	public void Start() {
		rotationInit = transform.rotation;
		OnAction (false);
	}

	public void Update() {
		if (!gameObject.activeSelf)
			return;
		int timeSpin = (int)(Time.timeSinceLevelLoad) % ROTATE_SEC_COMPLETE;
		Quaternion rotationEnd = rotationInit * Quaternion.Euler (0f, (360 * (Time.timeSinceLevelLoad-timeSpin)/ROTATE_SEC_COMPLETE), 0f); 
		transform.rotation = rotationEnd; //Quaternion.Slerp (rotationInit, rotationEnd, Time.deltaTime); 
		//Debug.Log (transform.rotation);
	}


	private void OnAction(bool triggerAudio) {
		if (effectPrefab) {
			Instantiate (effectPrefab, transform.position, rotationInit);
		}
		if (triggerAudio && clipAction) {
			AudioSource sourcePlayer = Camera.main.GetComponent<AudioSource> ();
			if (sourcePlayer)
				sourcePlayer.PlayOneShot(clipAction);
		}
	}

	public void OnKeyClicked() {
		Debug.Log ("Key clicked, attempting prefab...");
		OnAction (true);
		if (objInventory)
			objInventory.updateInventory ("keys");
		//Destroy(gameObject);
		gameObject.SetActive(false);		

		// Call the Unlock() method on the Door
		// Set the Key Collected Variable to true
		// Destroy the key. Check the Unity documentation on how to use Destroy
	}




}
