using UnityEngine;
using System.Collections;

public class SpiderWalk : MonoBehaviour
{
    public float speed = 2.5f;
    private int direction = 1;
    private bool facingRight = true;

    private void Start()
    {
        if (Random.Range(0.0f, 1.0f) < 0.5)
        {
            direction = -1;
            facingRight = false;
            Flip();
        }
    }

    private void FixedUpdate()
    {
        Vector2 trans = this.transform.position;
        trans.x += Time.deltaTime*speed*direction;
        this.transform.position = trans;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Boundary")
        {
            direction *= -1;
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        facingRight = !facingRight;
        transform.localScale = theScale;
    }
}