﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderExplode : MonoBehaviour {
	
	public float flashRate = 0.2f;
	public int flashesBeforeExploding = 4;

	private float elapsedTime;
	private Color prevColor;
	private int colorSwaps;
	private GameObject explosion;
	private GameObject helper;
	private GameObject player;
	
	public bool exTriggered = false;
	public bool targetPlayer;
	public bool exploding;
	public bool inRange = false;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		explosion = transform.GetChild(0).gameObject;
		helper = transform.GetChild(1).gameObject;
		Reset();
	}
	

	void FixedUpdate () {
		GetComponent<SpiderWalk>().enabled = true;
		if(exTriggered)
			PrepareToExplode();
	}

	void SwapColors () {
		Color temp = GetComponent<SpriteRenderer> ().material.color;
		GetComponent<SpriteRenderer> ().material.color = prevColor;
		prevColor = temp;
	}

	void PrepareToExplode () {
		helper.SetActive(false);
		GetComponent<SpiderWalk>().enabled = false;
		elapsedTime += Time.deltaTime;

		if (elapsedTime >= flashRate) {
			SwapColors ();
			colorSwaps += 1;
			elapsedTime = 0.0f;
		}

		if (colorSwaps / 2 >= flashesBeforeExploding) {
			StartCoroutine(Explode());
		}
	}

	public void Reset(){
		inRange = false;
		targetPlayer = true;
		exploding = false;
		explosion.SetActive(false);
		prevColor =  new Color ( 255, 255, 255, 0.3f);
		colorSwaps = 0;
		elapsedTime = 0.0f;
		exTriggered = false;
		GetComponent<SpriteRenderer> ().material.color = new Color (.7f, .7f, .7f, 1f);
		GetComponent<SpiderWalk>().enabled = true;
	}

	public IEnumerator Explode () {
		explosion.SetActive(true);
		exploding = true;
		helper.SetActive(true);
		yield return new WaitForSeconds(1f);
		if(inRange){
			player.SendMessage("TakeDamage");
		}
		Reset();
		gameObject.SetActive(false);
	}

}










