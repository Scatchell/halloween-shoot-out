using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {
	private int score = 0;
	private int skeletonDeathPoints = 1;

	private const string scorePrependText = "Score: ";

	public void ScoreUp() {
		score += skeletonDeathPoints;

		gameObject.GetComponent<TextMesh> ().text = scorePrependText + score;
	}
}
