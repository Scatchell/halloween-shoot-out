using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	private float speed = .02f;
	bool paused = true;
	private Vector3 startPosition;
	private GameObject player;

	const float SKELETON_ATTACK_DISTANCE = 2.0f;

	void Start () {
		startPosition = gameObject.transform.position;
		player = GameObject.Find ("PlayerMarker");

		RotateTowardsPlayer ();
		Invoke ("StartMovement", 3f);
	}

	public void RotateTowardsPlayer(){
		//extract this
		var towardPlayer = new Vector3 (player.transform.position.x, startPosition.y, player.transform.position.z);
		gameObject.transform.LookAt (towardPlayer);

	}
	public void PauseMovement () {
		paused = true;
	}

	public void StartMovement () {
		paused = false;
	}

	public void Attack() {
		gameObject.GetComponent<AttackScript> ().AttackPlayer ();
	}

	void Update () {
		if (!paused) {
			Vector3 movement = Vector3.MoveTowards (gameObject.transform.position, player.transform.position, speed);
			gameObject.transform.position = new Vector3 (movement.x, startPosition.y, movement.z);

			RotateTowardsPlayer ();

			float distanceFromPlayer = Vector3.Distance(player.transform.position, gameObject.transform.position);
			if(distanceFromPlayer < SKELETON_ATTACK_DISTANCE) {
				Attack ();
			}
		} else {
			gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0.0f, 0.0f, 0.0f);;
		}
	}

	public void SetCameraEye(GameObject cameraEye) {
	}
}
