using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderExplode : MonoBehaviour {

	public GameObject player;
	public float triggerDistance = 3.0f;
	public float flashRate = 0.2f;
	public int flashesBeforeExploding = 4;

	private float elapsedTime;
	private Color prevColor;
	private int colorSwaps;
	private ParticleSystem explosion;

	private List<GameObject> inBlastZone;
	
	void Start () {
		prevColor =  new Color ( 255, 255, 255, 0.3f);

		explosion = GetComponent<ParticleSystem> ();
		explosion.Pause ();

		elapsedTime = 0.0f;
		colorSwaps = 0;
	}

	void FixedUpdate () {
		float distance = Mathf.Sqrt (
			Mathf.Pow (
				Mathf.Abs (this.transform.position.x - player.transform.position.x), 2) + 
			Mathf.Pow (
				Mathf.Abs (this.transform.position.y - player.transform.position.y), 2));

		if (distance <= triggerDistance) {
			GetComponent<SpiderWalk>().enabled = false;
			PrepareToExplode ();
		} else {
			GetComponent<SpiderWalk>().enabled = true;
			elapsedTime = 0.0f;
		}
	}

	void SwapColors () {
		Color temp = GetComponent<SpriteRenderer> ().material.color;
		GetComponent<SpriteRenderer> ().material.color = prevColor;
		prevColor = temp;
	}

	void PrepareToExplode () {
		elapsedTime += Time.deltaTime;

		if (elapsedTime >= flashRate) {
			SwapColors ();
			colorSwaps += 1;
			elapsedTime = 0.0f;
		}

		if (colorSwaps / 2 >= flashesBeforeExploding) {
			Explode ();
		}
	}

	void Explode () {
		GetComponent<SpriteRenderer> ().material.color = new Color (0, 0, 0, 0.0f);
		explosion.Play();
	}

	void OnTriggerEnter (Collider coll) {

	}
}










