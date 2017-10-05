using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IGameInterface 
{
	public GameObject effectPrefab = null;

	//private Quaternion rotationInit;
	private const float ROTATE_PER_SEC = 360f/4f;	//complete rotation in 4 seconds

	public void Reset() {
		gameObject.SetActive (true);
	}

	public void Start() {
		//rotationInit = transform.localRotation;
	}

	void OnEnable() {
		OnAction (false);
	}

	public void Update() {
		if (!gameObject.activeSelf)
			return;
		transform.localRotation = transform.localRotation * Quaternion.Euler(0f, 0f, ROTATE_PER_SEC*Time.deltaTime);
		//Debug.Log (transform.rotation);
	}

	private void OnAction(bool triggerEffect) {
		if (triggerEffect && effectPrefab) {
			Instantiate (effectPrefab, transform.position, effectPrefab.transform.rotation );
		}
	}

	public void OnKeyClicked() {
		Debug.Log ("Key clicked, attempting prefab...");
		OnAction (true);

		GameObject objPlayer = GameObject.FindGameObjectWithTag ("Player");
		Inventory objInventory = null;
		if (objPlayer)
			objInventory = objPlayer.GetComponent<Inventory> ();
		if (objInventory)
			objInventory.updateInventory ("keys");
		//Destroy(gameObject);
		gameObject.SetActive(false);		

		// Call the Unlock() method on the Door
		// Set the Key Collected Variable to true
		// Destroy the key. Check the Unity documentation on how to use Destroy
	}


}
