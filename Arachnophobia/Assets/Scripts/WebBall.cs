using UnityEngine;
using System.Collections;

public class WebBall : MonoBehaviour
{
    public float speed = 5.0f;

    // Use this for initialization
    private void Start()
    {
        if (Random.Range(0.0f, 1.0f) <= 0.5)
        {
            transform.position = new Vector2(-10.40f, -5.5f);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
        }
        else
        {
            transform.position = new Vector2(10.40f, -5.5f);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-1*speed, 0), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if ((coll.gameObject.tag == "Boundary") || (coll.gameObject.tag == "Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
