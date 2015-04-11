using UnityEngine;
using System.Collections;

public class BookController : MonoBehaviour {

	public GameObject TutorialDisplay;

	// Use this for initialization
	void Awake () {
		TutorialDisplay.SetActive(false);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player")
			TutorialDisplay.SetActive(true);
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Player")
			TutorialDisplay.SetActive(false);
	}
}
