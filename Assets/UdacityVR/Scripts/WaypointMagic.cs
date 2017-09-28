using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMagic : MonoBehaviour {
	public GameObject magicWaypointsContainer = null;		//container for magic points
	public GameObject normalWaypointsContainer = null;		//container for normal points
	public GameObject penthouseWaypoint = null;				//specific penthouse waypoint
	public GameObject initialWaypoint = null;				//starter waypoint (if null, will go to first "normal")

	private GameObject penthouseReturn = null;
	private int idxMagic = 0;

	// Use this for initialization
	void Start () {
		// reset camera to first normal waypoint
		// collect set of magic waypoints
		if (initialWaypoint) {
			gotoWaypoint (initialWaypoint.GetComponent<Waypoint>());
		}
		else if (normalWaypointsContainer) {
			Waypoint[] childrenObj = normalWaypointsContainer.GetComponentsInChildren<Waypoint>();
			gotoWaypoint (childrenObj [0]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void gotoWaypoint(Waypoint objWaypoint) {
		if (!objWaypoint)
			return;
		objWaypoint.Click ();
	}

	public void gotoMagic() {
		if (!magicWaypointsContainer)
			return;
		Waypoint[] childrenObj = magicWaypointsContainer.GetComponentsInChildren<Waypoint>();
		gotoWaypoint (childrenObj [idxMagic]);
		idxMagic = (idxMagic + 1) % childrenObj.Length;
	}

	public void togglePenthouse() {
		if (!penthouseWaypoint)	//must be set in editor
			return;
		if (penthouseReturn) {	//already at penthouse?
			gotoWaypoint (penthouseReturn.GetComponent<Waypoint>());
			penthouseReturn = null;
		} else {
			float minDist = 1e10f;  //sq dist to object
			Waypoint minDistObj = null;  //actual object from camera
			Vector3 vec3Pos = Camera.main.transform.parent.transform.position;

			foreach (GameObject objContain in new [] {magicWaypointsContainer, normalWaypointsContainer} ) {
				if (objContain) {
					Waypoint[] arrChild = objContain.GetComponentsInChildren<Waypoint>();	//get childen
					foreach (Waypoint go in arrChild) {	//loop over children
						Vector3 diff = go.transform.position - vec3Pos;	//position difference
						float curDistance = diff.sqrMagnitude;	//translate to float
						if (curDistance < minDist) {
							minDistObj = go;
							minDist = curDistance;
						}
					}
				}
			}
			if (minDistObj) { //sanity for valid found
				penthouseReturn = minDistObj.gameObject;
				gotoWaypoint (penthouseWaypoint.GetComponent<Waypoint>());
			}
		}	//end going TO penthouse
	}	//end penthouse toggle


}
