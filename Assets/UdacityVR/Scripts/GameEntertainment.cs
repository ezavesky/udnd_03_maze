using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntertainment : MonoBehaviour, IGameInterface {
	public GameObject objPrize;

	public void Reset () {
		if (objPrize)
			objPrize.SetActive (true);
	}
}
