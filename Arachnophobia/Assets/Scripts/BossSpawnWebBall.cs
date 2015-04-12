using UnityEngine;
using System.Collections;

public class BossSpawnWebBall : MonoBehaviour {

	public Transform webBallPrefab;

	// Use this for initialization
	void Start () {
	
	}

/*
	void FixedUpdate () {
		GameObject webBall = Transform.find ("WebBall");

		if (webBall != null) {
	
		}
	}
*/
	
	// Update is called once per frame
	void SpawnWebBall (float speed) {

		if (Random.Range (0.0f, 1.0f) <= 0.5) {
			//Object webBall = Instantiate(webBallPrefab, Vector3(-10.40, -3.20, 0), Quaternion.identity);

			//webBall.rigidBody.
		}

	}
}
