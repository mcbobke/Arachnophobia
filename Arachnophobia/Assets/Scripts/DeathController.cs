using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class DeathController : MonoBehaviour {

    public GameObject deathSprite;

    void Awake()
    {
        deathSprite.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void Death()
    {
        deathSprite.SetActive(true);
    }
}
