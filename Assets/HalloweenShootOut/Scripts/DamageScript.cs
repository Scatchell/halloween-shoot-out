using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {

	private int health = 4;
	private int hitDamage = 2;
	private float movementPauseDuration = 1.5f;
	private AudioSource skeletonSoundPlayer;
	public AudioClip skeletonInjuryNoise;
	public AudioClip secondSkeletonInjuryNoise;
	private Scoring playerScore;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
		playerScore = GameObject.Find ("ScoreText").GetComponent<Scoring>();
		skeletonSoundPlayer = GameObject.Find ("Skeleton Sounds").GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider collider) {
		if (IsAlive ()) {
			if (collider.gameObject.name == "Arrow") {
				Hit (hitDamage);
			} else if (collider.gameObject.name == "BasicBow") {
				Hit (hitDamage - 1);
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

	private void IncreasePlayerScore ()
	{
		playerScore.ScoreUp ();
	}

	void Hit(int damage) {
		health -= damage;
		PlaySkeletonInjuryNoise ();
		CancelInvoke ();
		PauseMovement ();
		if (health > 0) {
			Invoke ("StartMovement", movementPauseDuration);
		} else {
			IncreasePlayerScore ();
			gameObject.GetComponent<AttackScript> ().StopAttacking ();
		}

		animator.Play(health == 0 ? "Death" : "Hit");
	}

	private void PlaySkeletonInjuryNoise() {
		AudioClip skeletonNoise = Random.Range (0, 2) == 1 ? skeletonInjuryNoise : secondSkeletonInjuryNoise;
		skeletonSoundPlayer.clip = skeletonNoise;
		skeletonSoundPlayer.Play ();
	}
	// Update is called once per frame
	void Update () {
		if (!IsAlive ()) {
			var position = gameObject.transform.position;
			gameObject.transform.position = Vector3.MoveTowards (position, new Vector3 (position.x, 0.6f, position.z), 0.005f);
		}
	}
}
