using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

	public float attackRate = 0.005f;

	public GameObject webBallPrefab;
	public GameObject armPrefab;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate () {
		if (Random.Range (0.0f, 1.0f) <= attackRate) {				// to attack or not
			float randomAttack = Random.Range(0.0f, 1.0f);
		
			if (randomAttack <= 0.33f) {							// which attack to do
				// SquashAttack
			} else if (randomAttack <= 0.66f) {
				// PincerAttack
			} else {
				SpawnWebBall();
			}
		}
	}


	void SpawnWebBall () {
		Instantiate (webBallPrefab, new Vector2 (-10.40f, -5.0f), new Quaternion (0f, 0f, 0f, 0f));
	}

	void PincerAttack () {
	}

	void SquashAttack () {
	}
}
