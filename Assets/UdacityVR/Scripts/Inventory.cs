using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public Text textInventory = null;
	public Door doorObject = null;

	private int numCoins = 0;
	private int numKeys = 0;

	// Use this for initialization
	void Start () {
		updateInventory (null);
	}

	public void updateInventory(string type) {
		switch(type) {
			case "coin": numCoins += 1; break;
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
			//TODO, update the text?
		}
	}

	public void ResetGame() {
		//reset all hilights
		foreach (GameObject objHilight in GameObject.FindGameObjectsWithTag("Hilight")) {
			IHilightBase hilightBase = objHilight.GetComponent<IHilightBase>();
			if (hilightBase != null) 
				hilightBase.Reset();
		}

		//reset inventory
		numCoins = 0;
		numKeys = 0;

		//reset to first magic waypoint
		GameObject objWaypoint = GameObject.FindGameObjectWithTag ("Respawn");
		Waypoint waypointInitial = null;
		if (objWaypoint)
			waypointInitial = objWaypoint.GetComponent<Waypoint> ();
		if (waypointInitial)
			waypointInitial.Click ();
	}
}
