using UnityEngine;
using System.Collections;

public class ArmDamageEnd : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			other.gameObject.SendMessage("TakeDamage");
			//Screenshake
		}
	}
}
