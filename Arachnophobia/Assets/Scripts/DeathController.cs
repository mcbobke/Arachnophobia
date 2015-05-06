using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class DeathController : MonoBehaviour
{
    public GameObject deathSprite;

    private void Awake()
    {
        deathSprite.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void Death()
    {
        deathSprite.SetActive(true);
        deathSprite.GetComponent<AudioSource>().Play();
    }
}
