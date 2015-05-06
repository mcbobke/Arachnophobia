using UnityEngine;
using System.Collections;

public class ExplosionHelper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GetComponentInParent<SpiderExplode>().exTriggered = true;
            GetComponentInParent<SpiderExplode>().inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            GetComponentInParent<SpiderExplode>().inRange = false;
    }
}