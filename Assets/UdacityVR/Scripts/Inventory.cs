using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public Text textInventory = null;
	public Door doorObject = null;

	private int numCoins = 0;
	private int numKeys = 0;
	private IGameInterface[] gameToggles;

	// Use this for initialization
	void Start () {
		updateInventory (null);

		GameObject[] setHilights = GameObject.FindGameObjectsWithTag("Game");
		gameToggles = new IGameInterface[setHilights.Length];
		for (int idx=0; idx<setHilights.Length; idx++) {
			gameToggles[idx] = setHilights[idx].GetComponent<IGameInterface>();
		}
	}

	public void updateInventory(string type) {
		switch(type) {
			case "coin": 
				numCoins += 1; 
				break;
			case "keys": 
				numKeys += 1; 
				if (doorObject)
					doorObject.LockSet (false);
				break;
			default: break;
		}

		if (textInventory) {
			textInventory.text = string.Format("Inventory\n{0} coin{1}, {2} key{3}", 
				numCoins, numCoins==1 ? "" : "s", numKeys, numKeys==1 ? "" : "s");
		}
	}

	public void ResetGame() {
		//reset all "resetable" game objects
		for (int idx=0; idx<gameToggles.Length; idx++) {
			if (gameToggles[idx] != null) 
				gameToggles[idx].Reset ();
		}
				
		//reset inventory
		numCoins = 0;
		numKeys = 0;
		updateInventory ("");

		//reset to first magic waypoint
		GameObject objWaypoint = GameObject.FindGameObjectWithTag ("Respawn");
		Waypoint waypointInitial = null;
		if (objWaypoint)
			waypointInitial = objWaypoint.GetComponent<Waypoint> ();
		if (waypointInitial)
			waypointInitial.Click ();
	}
}
