using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log("Collided!");
		Debug.Log (collider);
		Debug.Log (collider.tag);
		if (collider.gameObject.name == "Arrow") {
			Debug.Log("Is arrow!");
			gameObject.GetComponent<Animator>().Play("Hit");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
