using UnityEngine;
using System.Collections;

public class PlayerExplode : MonoBehaviour
{
    private GameObject gc;

    private void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");
        StartCoroutine("Clear");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            other.gameObject.SetActive(false);
            gc.GetComponent<EnemySpawner>().active -= 1;
            gc.GetComponent<EnemySpawner>().KillCount++;
        }
    }

    private IEnumerator Clear()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject, 0f);
    }
}
