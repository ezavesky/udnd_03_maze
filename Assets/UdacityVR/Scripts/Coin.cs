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
	private const float ROTATE_PER_SEC = 360f/4f;	//complete rotation in 4 seconds

	public void Start() {
		rotationInit = transform.rotation;
		OnAction ();
	}

	public void Update() {
		if (!gameObject.activeSelf)
			return;
		transform.rotation = transform.rotation * Quaternion.Euler(0f, ROTATE_PER_SEC*Time.deltaTime, 0f);
		//Debug.Log (transform.rotation);
	}

	private void OnAction(bool triggerAudio=true) {
		if (effectPrefab) {
			Instantiate (effectPrefab, transform.position, rotationInit);
		}
		if (triggerAudio && clipAction) {
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
