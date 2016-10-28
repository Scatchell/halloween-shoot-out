using UnityEngine;
using System.Collections;

public class PopOutWhenGazed : SteamVR_GazeTracker {

	public void OnGazeOn(GazeEventArgs e)
	{
		base.OnGazeOn (e);
		Debug.Log ("Gazed!");
		gameObject.GetComponent<MeshRenderer> ().material.color = Color.green;
	}



}
