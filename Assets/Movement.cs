using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed;
	bool paused = false;

	void Start () {
	
	}

	void PauseMovement () {
		paused = true;
	}

	void StartMovement () {
		paused = false;
	}

	void Update () {
		if (!paused) {
			Vector3 movement = new Vector3 (0.0f, 0.0f, 1f);
			gameObject.GetComponent<Rigidbody> ().velocity = movement * speed;
		}
	}
}
