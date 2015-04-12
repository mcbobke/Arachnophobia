using UnityEngine;
using System.Collections;

public class ExplosionHelper : MonoBehaviour
{
	void Start(){

	}
    void OnTriggerEnter2D(Collider2D coll)
    {
		if (transform.parent.gameObject.GetComponent<SpiderExplode>().exploding){
			bool target = transform.parent.gameObject.GetComponent<SpiderExplode>().targetPlayer;
			Debug.Log(coll.gameObject.name);
			if(!target && (coll.gameObject.tag == "Spider" || coll.gameObject.tag == "ExplodeSpider")){
				coll.gameObject.SetActive(false);
			}
		}
        if (coll.gameObject.tag == "Player")
        {
            GetComponentInParent<SpiderExplode>().exTriggered = true;
        }
    }
}