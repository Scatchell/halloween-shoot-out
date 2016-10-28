using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	private bool isRunning = false;
	// Use this for initialization
	void Start () {
		
	}

	public void Begin() {
		if (!isRunning) {
			gameObject.GetComponent<CreateSkeletons> ().Begin ();
			isRunning = true;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
