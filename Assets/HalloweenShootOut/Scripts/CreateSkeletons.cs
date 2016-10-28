﻿using UnityEngine;
using System.Collections;

public class CreateSkeletons : MonoBehaviour {
	public GameObject skeletonPrefab;
	private const int MIN_RANGE = 8;
	private const int MAX_RANGE = 20;
	public AudioClip skeletonCreationClip;
	public AudioSource skeletonNoisePlayer;

	// Use this for initialization
	void Start () {
		skeletonNoisePlayer.clip = skeletonCreationClip;
	}

	public void Begin() {
		InvokeRepeating("SpawnSkeleton", 2.0f, 8.0f);
	}

	public void Stop() {
		CancelInvoke ();
	}

	static float RandomPosition ()
	{
		bool negative = Random.Range (0, 2) == 1 ? true : false;
		int randomNumber = Random.Range (MIN_RANGE, MAX_RANGE);
		return (negative ? -randomNumber : randomNumber);
	}

	private void SpawnSkeleton() {
		skeletonNoisePlayer.Play ();

		float randomZ = RandomPosition ();
		float randomX = RandomPosition ();

		Instantiate (skeletonPrefab, new Vector3 (randomX, 1f, randomZ), Quaternion.Euler (new Vector3 (0, 0, 0)));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
