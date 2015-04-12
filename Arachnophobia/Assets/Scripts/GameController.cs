using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject Web;

    public void DeactivateSpider(GameObject obj)
    {
        if (obj.tag == "WebSpider")
        {
            Vector3 pos = obj.transform.position;
            Debug.Log(pos);
            Instantiate(Web, new Vector2(pos.x, pos.y + .3f), new Quaternion(0f, 0f, 0f, 0f));
        }
    }
}