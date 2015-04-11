using UnityEngine;
using System.Collections;

public class SpiderWalkRandom : MonoBehaviour {
	
	public float speed = 2.5f;
	public float directionChangeRate = 0.2f;
	
	private int direction = 1;
	
	void Start () {
		if (Random.Range (0.0f, 1.0f) < 0.5) {
			direction = -1;
		}
	}
	
	void FixedUpdate () {
		if (Random.Range (0.0f, 1.0f) <= directionChangeRate) {
			direction *= -1;
		}

		Vector2 trans = this.transform.position;
		trans.x += Time.deltaTime * speed * direction;
		this.transform.position = trans;
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Boundary") {
            Vector2 tempVec = GetComponent<Rigidbody2D>().velocity;
			tempVec.x *= -1;
            GetComponent<Rigidbody2D>().velocity = tempVec;
		}
	}
}