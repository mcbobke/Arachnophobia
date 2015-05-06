using UnityEngine;
using System.Collections;

public class BossSpawnWebBall : MonoBehaviour
{
    public GameObject webBallPrefab;

    // Update is called once per frame
    private void SpawnWebBall(float speed)
    {
        Instantiate(webBallPrefab, new Vector2(-10.40f, -3.50f), new Quaternion(0f, 0f, 0f, 0f));

        if (Random.Range(0.0f, 1.0f) <= 0.5)
        {
            //Object webBall = Instantiate(webBallPrefab, Vector3(-10.40, -3.20, 0), Quaternion.identity);

            //webBall.rigidBody.
        }
    }
}
