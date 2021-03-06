﻿using UnityEngine;
using System.Collections;

public class StartGameTrigger : MonoBehaviour
{
    //Deactivates for game start
    public GameObject GameController;
    public GameObject PreGame;
    public GameObject Title;
    public GameObject Canvas;
    public GameObject Images;

    // Use this for initialization
    private void Awake()
    {
        GameController.SetActive(false);
        PreGame.SetActive(true);
        Title.SetActive(true);
        Canvas.SetActive(false);
        Images.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameController.SetActive(true);
            PreGame.SetActive(false);
            gameObject.SetActive(false);
            GameController.GetComponent<AudioSource>().Play();
            Title.SetActive(false);
            Canvas.SetActive(true);
            Images.SetActive(true);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
