using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	private bool isRunning = false;
	public AudioSource backgroundMusic;
	public AudioClip backgroundMusicClip;

	// Use this for initialization
	void Start () {
		Begin ();
	}

	public void Begin() {
		if (!isRunning) {
			gameObject.GetComponent<CreateSkeletons> ().Begin ();
			PlayMusic ();
			isRunning = true;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

	private void PlayMusic(){
		backgroundMusic.clip = backgroundMusicClip;
		backgroundMusic.Play ();
	}
}
