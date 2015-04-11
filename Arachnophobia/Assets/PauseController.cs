using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public GameObject InGameMenu;				//For accessing in game menu with script

	bool Paused = false;						//Records if game is paused or not

	// Use this for initialization
	void Awake () {
		InGameMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P) && !Paused)
			PauseGame();
		else if (Input.GetKeyDown(KeyCode.P) && Paused)
			ResumeGame();
	}

	void PauseGame(){
		Paused = true;
		InGameMenu.SetActive(true);
		Time.timeScale = 0.0f;
	}

	void ResumeGame(){
		Paused = false;
		InGameMenu.SetActive(false);
		Time.timeScale = 1.0f;
	}
}
