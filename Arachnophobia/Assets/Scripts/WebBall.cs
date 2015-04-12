using UnityEngine;
using System.Collections;

public class WebBall : MonoBehaviour {

/*
	public float speed = 2.5f;
	public int direction = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}
*/

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Boundary") {
			Destroy(this.gameObject);
		}
	}
}
