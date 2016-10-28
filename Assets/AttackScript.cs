using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

	private int health = 2;
	private int hitDamage = 1;
	private float movementPauseDuration = 1.5f;
	private AudioSource skeletonSoundPlayer;
	public AudioClip attackNoise;
	private bool isAttacking = false;
	private Animator animator;
	private Player player;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
		skeletonSoundPlayer = GameObject.Find ("Skeleton Sounds").GetComponent<AudioSource>();
		player = GameObject.Find ("Player").GetComponent<Player>();
	}

	private void Attack(){
		gameObject.GetComponent<Movement> ().RotateTowardsPlayer ();
		player.DecrementHealth ();
		gameObject.GetComponent<Movement> ().PauseMovement ();
		animator.Play ("SwingHeavy");
		skeletonSoundPlayer.clip = attackNoise;
		skeletonSoundPlayer.Play ();
	}

	public void AttackPlayer ()
	{
		if (!isAttacking) {
			isAttacking = true;
			InvokeRepeating ("Attack", 1f, 3f);
		}
	}

	public void StopAttacking() {
		isAttacking = false;
		CancelInvoke ();
	}

	// Update is called once per frame
	void Update () {
	}
}
