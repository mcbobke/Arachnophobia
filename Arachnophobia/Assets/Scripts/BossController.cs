using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

	public float attackRate = 0.005f;

	public GameObject webBallPrefab;
	public GameObject armPrefab;

	private Transform[] children = new Transform[5];
	private GameObject cam;

	private bool activated;

	public int BossHealth = 10;
	int health;

	// Use this for initialization
	void Awake(){
		health = BossHealth;
		cam = GameObject.FindGameObjectWithTag("MainCamera");		
		Intialize();
		int i = 0;
		foreach(Transform child in transform){
			children[i] = child;
			child.gameObject.SetActive(false);
			i++;
		}
	}

	void Intialize(){
		transform.position = new Vector3(0f,-9.7f,transform.position.z);
		activated = false;
		BossHealth = health;
		gameObject.SetActive(false);
	}

	IEnumerator Death(){
		Vector2 position = new Vector2(transform.position.x, transform.position.y);
		transform.position  = Vector2.MoveTowards(position, new Vector2(0f,-9.7f),.1f);
		yield return new WaitForSeconds(1.8f);
		Intialize();
	}


	void FixedUpdate () {;
		if(activated){
			if (Random.Range (0.0f, 1.0f) <= attackRate) {				// to attack or not
				float randomAttack = Random.Range(0.0f, 1.0f);
			
				if (randomAttack <= 0.33f) {							// which attack to do
					SquashAttack();
				} else if (randomAttack <= 0.66f) {
					SmashAttack();
				} else {
					SpawnWebBall();
				}
			}
			if(BossHealth <= 0){
				StartCoroutine("Death");
			}
		}
		else{
			Vector2 current = new Vector2(transform.position.x, transform.position.y);
			if(current == new Vector2(0f,.8f))
				activated = true;
			transform.position = Vector2.MoveTowards(current, new Vector2(0f,.8f),.1f);
			cam.GetComponent<CameraController>().Shake();
		}
	}




	void SpawnWebBall () {
		Instantiate (webBallPrefab, new Vector2 (-10.40f, -5.0f), new Quaternion (0f, 0f, 0f, 0f));
	}

	void SmashAttack () {
		children [4].gameObject.SetActive (true);
	}

	public void TakeDamage(){
		GetComponent<Animator>().SetTrigger("hit");
		BossHealth--;
	}

	void SquashAttack () {
		children[2].gameObject.SetActive(true);
		children[3].gameObject.SetActive(true);
	}
}
