using UnityEngine;
using System.Collections;

public class ArmRamController : MonoBehaviour {

	public bool Left = true;

	Vector2 start;
	Vector2 destination;

	bool withdrawing = false;

	// Use this for initialization
	void Start () {
		if(Left){
			destination = new Vector2 (-6.2f, transform.position.y);
			transform.position = new Vector3(-18f,transform.position.y,transform.position.x);
		}
		else{
			destination = new Vector2 (6.2f, transform.position.y);
			transform.position = new Vector3(18f,transform.position.y,transform.position.x);
		}
		start = new Vector2 (transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if((transform.position != new Vector3(destination.x, destination.y, transform.position.z) && !withdrawing)){
			Vector2 current = new Vector2(transform.position.x, transform.position.y);
			transform.position = Vector2.MoveTowards(current,destination,.35f);
		}
		else if(withdrawing){
			Vector2 current = new Vector2(transform.position.x, transform.position.y);
			transform.position = Vector2.MoveTowards(current,start,.35f);
		}
		else
			StartCoroutine("Withdraw");
	}
	

	IEnumerator Withdraw(){
		yield return new WaitForSeconds(1f);
		withdrawing = true;
	}
}
