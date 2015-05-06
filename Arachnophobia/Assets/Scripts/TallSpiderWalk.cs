using UnityEngine;
using System.Collections;

public class TallSpiderWalk : MonoBehaviour
{
    public float speed = 2.5f;
    private int direction = -1;
    private bool facingRight = false;

    private void Start()
    {
        if (Random.Range(0.0f, 1.0f) < 0.5)
        {
            direction = 1;
            facingRight = true;
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

        else if (coll.gameObject.tag == "Ground")
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;

            BoxCollider2D[] allCollidersOnObject = GetComponentsInChildren<BoxCollider2D>();
                // Get ALL BoxCollider2D's that are attached to this tall spider as well as it's child objects

            foreach (BoxCollider2D boxcoll in allCollidersOnObject)
            {
                if (boxcoll.gameObject.transform.parent != null &&
                    boxcoll.gameObject.transform.parent.tag != "EnemyParent")
                    // This means the gameobject that this collider is attached to has a parent, so it must be the child
                {
                    boxcoll.enabled = false;
                }
            }
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
