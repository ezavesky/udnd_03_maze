using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
    //Create a reference to the CoinPoofPrefab
	public GameObject effectPrefab = null;

	private Quaternion rotationInit;
	private const float ROTATE_PER_SEC = 360f/4f;	//complete rotation in 4 seconds

	public void Start() {
		rotationInit = transform.localRotation;
	}

	void OnEnable() {
		OnAction ();
	}

	public void Update() {
		if (!gameObject.activeSelf)
			return;
		transform.localRotation = transform.localRotation * Quaternion.Euler(0f, ROTATE_PER_SEC*Time.deltaTime, 0f);
		//Debug.Log (transform.rotation);
	}

	private void OnAction(bool triggerEffect=true) {
		if (triggerEffect && effectPrefab) {
			GameObject newObj = Instantiate (effectPrefab, transform.position, effectPrefab.transform.rotation );
			//newObj.transform.parent = transform.parent;
		}
		/*
		if (triggerAudio) {
			AudioSource sourcePlayer = Camera.main.GetComponent<AudioSource> ();
			if (sourcePlayer)
				sourcePlayer.PlayOneShot(clipAction);
		}
		*/
	}

    public void OnCoinClicked() {
		Debug.Log ("Coin clicked, attempting prefab...");
		OnAction ();

		GameObject objPlayer = GameObject.FindGameObjectWithTag ("Player");
		Inventory objInventory = null;
		if (objPlayer)
			objInventory = objPlayer.GetComponent<Inventory> ();
		if (objInventory)
			objInventory.updateInventory ("coin");
		//Destroy(gameObject);
		gameObject.SetActive(false);		//NOTE: we don't destory because user can win coins again!
    }

}
