using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed;
	bool paused = true;
	private Vector3 startPosition;
	private GameObject player;

	void Start () {
		startPosition = gameObject.transform.position;
		player = GameObject.Find ("PlayerMarker");
		Invoke ("StartMovement", 3f);
	}

	public void PauseMovement () {
		paused = true;
	}

	public void StartMovement () {
		paused = false;
	}

	void Update () {
		if (!paused) {
			Vector3 movement = Vector3.MoveTowards (gameObject.transform.position, player.transform.position, .01f);
			gameObject.transform.position = new Vector3 (movement.x, startPosition.y, movement.z);

			var towardPlayer = new Vector3 (player.transform.position.x, startPosition.y, player.transform.position.z);
			gameObject.transform.LookAt (towardPlayer);
		} else {
			gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0.0f, 0.0f, 0.0f);;
		}
	}

	public void SetCameraEye(GameObject cameraEye) {
	}
}
