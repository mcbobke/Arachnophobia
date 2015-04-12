using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private float shakeIntensity;
    private float shakeDecay;
    private Vector3 originalCameraPos;

    // Use this for initialization
    void Start()
    {
        originalCameraPos = gameObject.transform.position;
        shakeIntensity = 0f;
        shakeDecay = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeIntensity > 0)
        {
            gameObject.transform.position = originalCameraPos + Random.insideUnitSphere * shakeIntensity;

            shakeIntensity -= Time.deltaTime * shakeDecay;
        }

        else
        {
            gameObject.transform.position = originalCameraPos;
        }
    }

    public void Shake()
    {
        shakeIntensity = 0.3f;
    }
}
