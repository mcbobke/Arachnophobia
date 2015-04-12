using UnityEngine;
using System.Collections;

public class PlayerExplode : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other){
		if(other.tag != "Player")
			other.gameObject.SetActive(false);
	}
}
