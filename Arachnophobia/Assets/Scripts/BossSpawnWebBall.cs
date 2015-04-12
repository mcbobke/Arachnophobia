using UnityEngine;
using System.Collections;

public class BossSpawnWebBall : MonoBehaviour {

	public GameObject webBallPrefab;

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
		Instantiate (webBallPrefab, new Vector2 (-10.40f, -3.50f), new Quaternion (0f, 0f, 0f, 0f));
	}
}
