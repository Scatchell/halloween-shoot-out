using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private bool isDying = false;
	private const float RATIO = .03f;
	private const float FALLING_SPEED = .3f;

	public int playerHealth = 10;
	public int damagePerHit = 1;

	// Use this for initialization
	void Start () {
	
	}

	public void Die(){
		GameObject.Find("root").GetComponent<CreateSkeletons> ().Stop();
		isDying = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDying) {
			gameObject.transform.rotation = Quaternion.RotateTowards (gameObject.transform.rotation, Quaternion.Euler (new Vector3 (0, 0, 88)), FALLING_SPEED);
			Vector3 position = gameObject.transform.position;
			gameObject.transform.position = Vector3.MoveTowards (position, new Vector3 (position.x, 2.0f, position.z), FALLING_SPEED * RATIO);
		}
	}

	public void DecrementHealth () {
		playerHealth -= damagePerHit;
		if (playerHealth < 1) {
			Die ();
		}
		Debug.Log (playerHealth);
	}
}
