using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {

	private int health = 2;
	private int hitDamage = 1;
	private float movementPauseDuration = 2f;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider collider) {
		if (IsAlive ()) {
			if (collider.gameObject.name == "Arrow") {
				Hit ();
			}
		}
	}

	bool IsAlive() {
		return health > 0;
	}

	private void PauseMovement ()
	{
		gameObject.GetComponent<Movement> ().PauseMovement ();
	}

	private void StartMovement ()
	{
		gameObject.GetComponent<Movement> ().StartMovement ();
	}

	void Hit() {
		health -= hitDamage;
		if (health > 0) {
			PauseMovement ();
			Invoke ("StartMovement", movementPauseDuration);
		}
		animator.Play(health == 0 ? "Death" : "Hit");
	}	
	// Update is called once per frame
	void Update () {
	
	}
}
