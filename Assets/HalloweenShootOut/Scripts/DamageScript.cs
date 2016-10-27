using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {

	private int health = 2;
	private int hitDamage = 1;
	private float movementPauseDuration = 1.5f;
	private AudioSource skeletonSoundPlayer;
	public AudioClip skeletonInjuryNoise;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
		skeletonSoundPlayer = GameObject.Find ("Skeleton Sounds").GetComponent<AudioSource>();
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
		Debug.Log ("Hit!");
		health -= hitDamage;
		PlaySkeletonInjuryNoise ();
		CancelInvoke ();
		PauseMovement ();
		if (health > 0) {
			Invoke ("StartMovement", movementPauseDuration);
		}

		animator.Play(health == 0 ? "Death" : "Hit");
	}

	private void PlaySkeletonInjuryNoise() {
		skeletonSoundPlayer.clip = skeletonInjuryNoise;
		skeletonSoundPlayer.Play ();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
