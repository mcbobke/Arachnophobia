﻿using UnityEngine;
using System.Collections;

public class SpiderWalk : MonoBehaviour {

	public float speed = 2.5f;

	private int direction = 1;
	
	void Start () {
		if (Random.Range (0.0f, 1.0f) < 0.5) {
			direction = -1;
		}
	}

	void FixedUpdate () {
		Vector2 trans = this.transform.position;
		trans.x += Time.deltaTime * speed * direction;
		this.transform.position = trans;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Boundary") {
			direction *= -1;
		}
	}
}