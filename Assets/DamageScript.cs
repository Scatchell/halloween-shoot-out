using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {

	private int health = 2;
	private int hitDamage = 1;

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

	void Hit() {
		health -= hitDamage;
		animator.Play(health == 0 ? "Death" : "Hit");
	}	
	// Update is called once per frame
	void Update () {
	
	}
}
