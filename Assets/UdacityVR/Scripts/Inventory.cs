using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public Text textInventory = null;

	private int numCoins = 0;
	private int numKeys = 0;

	// Use this for initialization
	void Start () {
		updateInventory (null);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateInventory(string type) {
		switch(type) {
			case "coin": numCoins += 1; break;
			case "keys": numKeys += 1; break;
			default: break;
		}

		if (textInventory) {
			textInventory.text = string.Format("Inventory\n{0} coin{2}, {2} key{3}", 
				numCoins, numCoins==1 ? "" : "s", numKeys, numKeys==1 ? "" : "s");
			//TODO, update the text?
		}
	}

}
