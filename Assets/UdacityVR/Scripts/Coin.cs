using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
    //Create a reference to the CoinPoofPrefab
	public GameObject effectPrefab = null;
	public AudioClip clipAction = null;
	public Inventory objInventory = null;

	private Quaternion rotationInit;
	private const int ROTATE_SEC_COMPLETE = 4;

	public void Start() {
		rotationInit = transform.rotation;
		OnAction ();
	}

	public void Update() {
		if (!gameObject.activeSelf)
			return;
		int timeSpin = (int)(Time.timeSinceLevelLoad) % ROTATE_SEC_COMPLETE;
		Quaternion rotationEnd = rotationInit * Quaternion.Euler (0f, (360 * (Time.timeSinceLevelLoad-timeSpin)/ROTATE_SEC_COMPLETE), 0f); 
		transform.rotation = rotationEnd; //Quaternion.Slerp (rotationInit, rotationEnd, Time.deltaTime); 
		//Debug.Log (transform.rotation);
	}


	private void OnAction() {
		if (effectPrefab) {
			Instantiate (effectPrefab, transform.position, rotationInit);
		}
		if (clipAction) {
			AudioSource sourcePlayer = Camera.main.GetComponent<AudioSource> ();
			if (sourcePlayer)
				sourcePlayer.PlayOneShot(clipAction);
		}
	}

    public void OnCoinClicked() {
		Debug.Log ("Coin clicked, attempting prefab...");
		OnAction ();
		if (objInventory)
			objInventory.updateInventory ("coin");
		//Destroy(gameObject);
		gameObject.SetActive(false);		//NOTE: we don't destory because user can win coins again!
    }

}
