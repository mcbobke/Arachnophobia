using UnityEngine;
using System.Collections;

public class PlayerExplode : MonoBehaviour {
	GameObject gc;

	void Awake(){
		gc = GameObject.FindGameObjectWithTag("GameController");
		StartCoroutine("Clear");
	}
	
	void OnTriggerStay2D(Collider2D other){
		if(other.tag != "Player"){
			other.gameObject.SetActive(false);
			gc.GetComponent<EnemySpawner>().active -=1;
		}
	}

	IEnumerator Clear(){
		yield return new WaitForSeconds(.5f);
		Destroy(this.gameObject,0f);
	}

}
