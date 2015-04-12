using UnityEngine;
using System.Collections;

public class ExplosionHelper : MonoBehaviour
{
	void Start(){

	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GetComponentInParent<SpiderExplode>().exTriggered = true;
        }
    }

	void OnTriggerStay2D(Collider2D coll){
		if (transform.parent.gameObject.GetComponent<SpiderExplode>().exploding){
			bool target = transform.parent.gameObject.GetComponent<SpiderExplode>().targetPlayer;
			if(!target && (coll.gameObject.tag == "Spider" || coll.gameObject.tag == "ExplodeSpider")){
				Debug.Log("MOO");
			}
		}
	}
}