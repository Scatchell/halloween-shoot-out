﻿using UnityEngine;
using System.Collections;

namespace VRTK
{
	public class Player : MonoBehaviour
	{
		private bool isDying = false;
		private const float RATIO = .03f;
		private const float FALLING_SPEED = .3f;
		public AudioClip fastHeartbeat;
		public AudioClip slowHeartbeat;

		public int playerHealth = 10;
		public int damagePerHit = 1;

		// Use this for initialization
		void Start ()
		{
	
		}

		public void Die ()
		{
			GameObject.Find ("root").GetComponent<CreateSkeletons> ().Stop ();
			isDying = true;
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (isDying) {
				gameObject.transform.rotation = Quaternion.RotateTowards (gameObject.transform.rotation, Quaternion.Euler (new Vector3 (0, 0, 88)), FALLING_SPEED);
				Vector3 position = gameObject.transform.position;
				gameObject.transform.position = Vector3.MoveTowards (position, new Vector3 (position.x, 2.0f, position.z), FALLING_SPEED * RATIO);
			}
		}

		public void DecrementHealth ()
		{
			VRTK_DeviceFinder.GetControllerLeftHand ().GetComponent<VRTK_ControllerActions>().TriggerHapticPulse(3000, 0.3f, 0.001f);
			VRTK_DeviceFinder.GetControllerRightHand ().GetComponent<VRTK_ControllerActions>().TriggerHapticPulse(3000, 0.3f, 0.001f);

			var audioSource = gameObject.GetComponent<AudioSource> ();
			playerHealth -= damagePerHit;
			if (playerHealth < 1) {
				Die ();
			} else if (playerHealth < 7) {
				audioSource.clip = slowHeartbeat;
				audioSource.Play ();
			} else if (playerHealth <= 2) {
				audioSource.clip = fastHeartbeat;
				audioSource.Play ();
			}

			Debug.Log (playerHealth);
		}
	}
}