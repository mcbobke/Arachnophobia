using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject Web;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeactivateSpider(GameObject obj)
    {
        if (obj.tag == "Spider")
        {
            Vector3 pos = obj.transform.position;
            Debug.Log(pos);
            Instantiate(Web, new Vector2(pos.x + .6f, pos.y + .6f), new Quaternion(0f, 0f, 0f, 0f));
        }
    }
}