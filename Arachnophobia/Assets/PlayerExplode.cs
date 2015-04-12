using UnityEngine;
using System.Collections;

public class PlayerExplode : MonoBehaviour {
	GameObject gc;

	void Awake(){
		gc = GameObject.FindGameObjectWithTag("GameController");
	}

	void OnTriggerStay2D(Collider2D other){
		if(other.tag != "Player"){
			other.gameObject.SetActive(false);
			gc.GetComponent<EnemySpawner>().active -=1;
		}
	}

}
