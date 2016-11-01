using UnityEngine;
using System.Collections;

public class CreateSkeletons : MonoBehaviour {


	public GameObject skeletonPrefab;
	private const int MIN_RANGE = 8;
	private const int MAX_RANGE = 20;
	public AudioClip skeletonCreationClip;
	public AudioSource skeletonNoisePlayer;
	public float spawnTime = 10.0f;

	// Use this for initialization
	void Start () {
	}

	public void Begin() {
		Invoke("SpawnSkeleton", spawnTime);
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

	public void ReduceSpawnTime() {
		if (spawnTime > 1.0f) {
			spawnTime -= 0.25f;
		}
	}

	private void SpawnSkeleton() {
		skeletonNoisePlayer.clip = skeletonCreationClip;
		skeletonNoisePlayer.Play ();

		float randomZ = RandomPosition ();
		float randomX = RandomPosition ();

		Instantiate (skeletonPrefab, new Vector3 (randomX, 1.2f, randomZ), Quaternion.Euler (new Vector3 (0, 0, 0)));
		ReduceSpawnTime ();
		Invoke("SpawnSkeleton", spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
