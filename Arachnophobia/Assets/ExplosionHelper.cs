using UnityEngine;
using System.Collections;

public class ExplosionHelper : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GetComponentInParent<SpiderExplode>().exTriggered = true;
        }
    }
}