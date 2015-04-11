using UnityEngine;
using System.Collections;

public class StartGameTrigger : MonoBehaviour {

	//Deactivates for game start
	public GameObject GameController;
	public GameObject PreGame;

	// Use this for initialization
	void Awake () {
		GameController.SetActive(false);
		PreGame.SetActive(true);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			GameController.SetActive(true);
			PreGame.SetActive(false);
			gameObject.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
