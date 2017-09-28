using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SignPost : MonoBehaviour
{	
	public Waypoint targetWaypoint = null;

	public void ResetScene() 
	{
        // Reset the scene when the user clicks the sign post
	}

	public void gotoWaypoint()
	{
		if (targetWaypoint)
			targetWaypoint.Click ();
	}
}