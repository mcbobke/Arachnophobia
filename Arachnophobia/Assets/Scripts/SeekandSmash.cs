using UnityEngine;
using System.Collections;

public class SeekandSmash : MonoBehaviour {

	private float minDistancefromOrigin;			// arm isn't long enough to reach any further than this close to the origin
	private float targetPoint;						// the part of the arm that the spider tries to line up with the player
	private bool isLeftArm;

	void Start () {
		minDistancefromOrigin = 2.5f;
		targetPoint = 3.5f;

		if (Random.Range (0.0f, 1.0f) <= 0.5) {
			isLeftArm = true;
			transform.position = new Vector2 (-17.5f, -1.62f);
			//transform.scale = new Vector2(2, 2);
		} else {
			isLeftArm = false;
			transform.position = new Vector2 (17.5f, -1.62f);
			//transform.scale = new Vector2(-2, 2);
		}
	}
	
	void FixedUpdate () {
//		if (transform.position.x + targetPoint)
	}

/*
	void RotateToZero () {
		if (transform.rotation.z >= 0) {
			Quaternion rot = transform.rotation;
			rot.Euler( 0, 0, Time.deltaTime * rotationSpeed * -1);
			transform.rotation = rot;
		} 
		else if (transform.rotation.z <= 0) {
			Quaternion rot = transform.rotation;
			rot.Euler( 0, 0, Time.deltaTime * rotationSpeed);
			transform.rotation = rot;
		} 
		else {
			return;
		}

		if (transform.rotation.z <= Mathf.Abs(Time.deltaTime * rotationSpeed)) {
			Vector2 rot = transform.rotation;
			rot.z = 0;
			transform.rotation = rot;
		}
	}
*/
}
