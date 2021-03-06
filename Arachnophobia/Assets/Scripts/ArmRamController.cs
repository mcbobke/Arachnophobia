﻿using UnityEngine;
using System.Collections;

public class ArmRamController : MonoBehaviour
{
    public bool Left = true;

    private Vector2 start;
    private Vector2 destination;

    private bool withdrawing = false;

    // Use this for initialization
    private void Start()
    {
        if (Left)
        {
            destination = new Vector2(-6.2f, transform.position.y);
            transform.position = new Vector3(-18f, transform.position.y, transform.position.x);
        }
        else
        {
            destination = new Vector2(6.2f, transform.position.y);
            transform.position = new Vector3(18f, transform.position.y, transform.position.x);
        }
        start = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if ((transform.position != new Vector3(destination.x, destination.y, transform.position.z) && !withdrawing))
        {
            Vector2 current = new Vector2(transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(current, destination, .35f);
        }
        else if (withdrawing)
        {
            if (transform.position != new Vector3(start.x, start.y, transform.position.z))
            {
                Vector2 current = new Vector2(transform.position.x, transform.position.y);
                transform.position = Vector2.MoveTowards(current, start, .35f);
            }
            else
            {
                withdrawing = false;
                gameObject.SetActive(false);
            }
        }
        else
            StartCoroutine("Withdraw");
    }


    private IEnumerator Withdraw()
    {
        yield return new WaitForSeconds(1f);
        withdrawing = true;
    }
}
