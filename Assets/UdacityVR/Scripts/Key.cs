using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
	public GameObject effectPrefab = null;
	public AudioClip clipAction = null;
	public Inventory objInventory = null;

	private Quaternion rotationInit;
	private const float ROTATE_PER_SEC = 360f/4f;	//complete rotation in 4 seconds

	public void Start() {
		rotationInit = transform.rotation;
	}

	public void Update() {
		if (!gameObject.activeSelf)
			return;
		transform.rotation = transform.rotation * Quaternion.Euler(0f, ROTATE_PER_SEC*Time.deltaTime, 0f);
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
