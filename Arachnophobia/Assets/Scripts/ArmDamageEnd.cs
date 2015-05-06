using UnityEngine;
using System.Collections;

public class ArmDamageEnd : MonoBehaviour
{
    private GameObject cam;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SendMessage("TakeDamage");
            cam.GetComponent<CameraController>().Shake();
        }
    }
}
