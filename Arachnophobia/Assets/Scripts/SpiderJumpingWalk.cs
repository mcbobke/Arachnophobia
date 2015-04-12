using UnityEngine;
using System.Collections;

public class SpiderJumpingWalk : MonoBehaviour {

	public float jumpHeight = 8.0f;
	public float jumpRate = 0.2f;

	private int direction = 1;
	private bool facingRight = true;
	
	void Start () {
		if (Random.Range (0.0f, 1.0f) < 0.5f) {
			direction = -1;
			facingRight = false;
			Flip ();
		}
	}
	
	void FixedUpdate () {

		if (GetComponent<Rigidbody2D> ().velocity.y == 0) {
			if (Random.Range (0.0f, 1.0f) <= jumpRate) {
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (2 * direction, jumpHeight), ForceMode2D.Impulse);
			}
		}

	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Boundary") {
			direction *= -1;
			Vector2 currentVelocity = GetComponent<Rigidbody2D> ().velocity;
			GetComponent<Rigidbody2D> ().AddForce(new Vector2 (currentVelocity.x * -1 * 2, 0), ForceMode2D.Impulse);
			Flip ();
		}
	}

	void Flip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		facingRight = !facingRight;
		transform.localScale = theScale;
	}
}
