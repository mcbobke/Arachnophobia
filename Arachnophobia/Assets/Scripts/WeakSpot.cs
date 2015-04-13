using UnityEngine;
using System.Collections;

public class WeakSpot : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other){
		Debug.Log(other.gameObject.tag);
		if(other.gameObject.tag == "Player")
			Debug.Log("Landed on Weak Spot");
	}
}
