﻿using UnityEngine;
using System.Collections;

public class ArmSquishController : MonoBehaviour
{
    public float armSpeed = 3.0f;
    public float secondsBeforeSmash = 3.0f;

    private float minDistancefromOrigin; // arm isn't long enough to reach any further than this close to the origin
    private float targetPoint; // the part of the arm that the spider tries to line up with the player
    private int isLeftArm;
    private GameObject player;

    private bool hasHitPlayer;

    private float timer;

    private void Start()
    {
        player = GameObject.Find("Player");
        minDistancefromOrigin = 2.5f;
        targetPoint = 3.5f;

        Initialize();
    }

    private void Initialize()
    {
        timer = 0.0f;
        hasHitPlayer = false;

        if (Random.Range(0.0f, 1.0f) <= 0.5)
        {
            isLeftArm = 1;
            transform.position = new Vector2(-17.5f, 1.62f);
            transform.localScale = new Vector2(2, 2);
        }
        else
        {
            isLeftArm = -1;
            transform.position = new Vector2(17.5f, 1.62f);
            transform.localScale = new Vector2(-2, 2);
        }
    }

    private void FixedUpdate()
    {
        if (hasHitPlayer == false)
        {
            if (timer < secondsBeforeSmash)
            {
                if ((Mathf.Abs(transform.position.x) >= minDistancefromOrigin))
                {
                    Vector2 current = new Vector2(transform.position.x, transform.position.y);
                    Vector2 destionation = new Vector2(player.transform.position.x - (isLeftArm*targetPoint),
                        transform.position.y);
                    transform.position = Vector2.MoveTowards(current, destionation, Time.deltaTime*armSpeed);
                }
            }
            else
            {
                if (transform.position.y > -6.1)
                {
                    // if arm is below the ground
                    Vector2 pos = new Vector2(transform.position.x, transform.position.y);
                    pos.y -= Time.deltaTime*armSpeed*2;
                    transform.position = pos;
                }

                if (timer >= secondsBeforeSmash*1.5)
                {
                    Vector2 pos = new Vector2(transform.position.x, transform.position.y);
                    pos.x -= Time.deltaTime*armSpeed*5*isLeftArm;
                    transform.position = pos;
                }
            }
        }
        else
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            pos.y += Time.deltaTime*armSpeed;
            transform.position = pos;
        }

        if ((Mathf.Abs(transform.position.x) > 18) || (transform.position.y > 7))
        {
            Initialize();
            this.gameObject.SetActive(false);
        }

        timer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            hasHitPlayer = true;
            coll.gameObject.SendMessage("TakeDamage");
        }
    }
}